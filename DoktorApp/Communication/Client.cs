using DoktorApp.Data_Management;
using Server;
using Server.Data;
using System;
using System.Net.Sockets;

namespace DoktorApp.Communication
{
	public class Client
	{
		private readonly TcpClient client;
		private NetworkStream stream;
		private readonly byte[] buffer;
		private string totalBuffer;
		private readonly PatientHandler patientHandler;
		public bool LoggedIn { get; set; }
		public string DoctorName { get; set; }


		public Client(PatientHandler patientHandler)
		{
			this.client = new TcpClient();
			this.buffer = new byte[1024];
			this.totalBuffer = string.Empty;
			this.patientHandler = patientHandler;
			this.LoggedIn = false;
			this.DoctorName = "default";
		}

		private void OnRead(IAsyncResult ar)
		{
			int count = this.stream.EndRead(ar);
			this.totalBuffer += Encrypter.Decrypt(this.buffer.SubArray(0, count), "password123");

			string eof = $"<{Tag.EOF.ToString()}>";

			while (this.totalBuffer.Contains(eof))
			{
				string packet = this.totalBuffer.Substring(0, this.totalBuffer.IndexOf(eof) + eof.Length);
				this.totalBuffer = this.totalBuffer.Substring(packet.IndexOf(eof) + eof.Length);

				this.HandlePacket(packet);
			}

			this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(this.OnRead), null);
		}

		private void HandlePacket(string packet)
		{
			string loginreaction = TagDecoder.GetValueByTag(Tag.LR, packet);
			Console.WriteLine(loginreaction);

			if (loginreaction != null)
			{
				Console.WriteLine(loginreaction);
				if (loginreaction == "true")
				{
					this.LoggedIn = true;
					Console.WriteLine("Logged In!");
				}
				if (loginreaction == "false")
				{
					this.LoggedIn = false;
				}
			}
			else
			{
				// HERE IS RAW DATA BEING DROPPED
				this.patientHandler.HandleMessage(packet);
				Console.WriteLine(packet);
			}
		}

		public void Write(string message)
		{
			byte[] encrypted = Encrypter.Encrypt(message, "password123");
			this.stream.Write(encrypted, 0, encrypted.Length);
			this.stream.Flush();
		}

		public void Connect(string server, int port)
		{
			this.client.Connect(server, port);
			this.stream = this.client.GetStream();

			this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(this.OnRead), null);
		}

		public void Disconnect()
		{
			this.stream.Close();
			this.client.Close();
		}
	}
}
