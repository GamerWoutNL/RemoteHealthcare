using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Server;
using Server.Data;

namespace Client
{
    class Client : IClient
    {
		private TcpClient _tcpClient;
        private NetworkStream _stream;
		private byte[] _buffer;
		private string totalBuffer;
		private string _ergoID;

		public Client()
		{
			this._tcpClient = new TcpClient();
			this._buffer = new byte[1024];
			this.totalBuffer = string.Empty;
		}

		public void Connect(string server, int port, string ergoID)
		{
			this._tcpClient.Connect(server, port);
			this._stream = this._tcpClient.GetStream();
			this._ergoID = ergoID;

			this._stream.BeginRead(this._buffer, 0, this._buffer.Length, new AsyncCallback(OnRead), null);
		}

		public void Disconnect()
		{
			this._stream.Close();
			this._tcpClient.Close();
		}

        private void OnRead(IAsyncResult ar)
        {
			int count = this._stream.EndRead(ar);
			this.totalBuffer += Encrypter.Decrypt(this._buffer.SubArray(0, count), "password123");

			string eof = $"<{Tag.EOF.ToString()}>";
			while (totalBuffer.Contains(eof))
			{
				string packet = totalBuffer.Substring(0, totalBuffer.IndexOf(eof) + eof.Length);
				totalBuffer = totalBuffer.Substring(packet.IndexOf(eof) + eof.Length);

				this.HandlePacket(packet);
			}

			this._stream.BeginRead(this._buffer, 0, this._buffer.Length, new AsyncCallback(OnRead), null);
		}

		private void HandlePacket(string packet)
		{
			string messageType = TagDecoder.GetValueByTag(Tag.MT, packet);
			if (messageType == "ergo")
			{
				this.HandleErgoMessage(packet);
			}
		}

		private void HandleErgoMessage(string packet)
		{
			string action = TagDecoder.GetValueByTag(Tag.AC, packet);
			if (action == "resistance")
			{
				this.HandleSetResistance(packet);
			}
			else if (action == "brake")
			{
				this.HandleEmergencyBrake(packet);
			}
			else if (action == "message")
			{
				this.HandleDoctorsMessage(packet);
			}
		}

		private void HandleDoctorsMessage(string packet)
		{
			string message = TagDecoder.GetValueByTag(Tag.DM, packet);
			Console.WriteLine($"Got a message from the doctor: {message}");

			//TODO: make this visual in the GUI
		}

		private void HandleEmergencyBrake(string packet)
		{
			// TODO: Set a emergency brake
			throw new NotImplementedException();
		}

		private void HandleSetResistance(string packet)
		{
			int resistancePercentage = int.Parse(TagDecoder.GetValueByTag(Tag.SR, packet));
			Console.WriteLine(resistancePercentage);
			//TODO: Set the resistance of the bike with this integer
		}

		public void Write(string message)
		{
			byte[] encrypted = Encrypter.Encrypt(message, "password123");
			this._stream.Write(encrypted, 0, encrypted.Length);
			this._stream.Flush();
		}
	}
}
