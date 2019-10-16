using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Server;
using Server.Data;

namespace DoktorApp.Communication
{
	public class Client
	{
		private TcpClient client;
		private NetworkStream stream;
		private byte[] buffer;
		private string totalBuffer;

		public Client()
		{
			this.client = new TcpClient();
			this.buffer = new byte[1024];
			this.totalBuffer = string.Empty;
		}

		private void OnRead(IAsyncResult ar)
		{
			int count = stream.EndRead(ar);
			this.totalBuffer += Encrypter.Decrypt(this.buffer.SubArray(0, count), "password123");

			string eof = $"<{Tag.EOF.ToString()}>";

			while (totalBuffer.Contains(eof))
			{
				string packet = totalBuffer.Substring(0, totalBuffer.IndexOf(eof) + eof.Length);
				totalBuffer = totalBuffer.Substring(packet.IndexOf(eof) + eof.Length);

				this.HandlePacket(packet);
			}

			this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(OnRead), null);
		}

		private void HandlePacket(string packet)
		{
			// HERE IS RAW DATA BEING DROPPED
			Console.WriteLine(packet);
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

			this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(OnRead), null);
		}

		public void Disconnect()
		{
			this.stream.Close();
			this.client.Close();
		}
	}
}
