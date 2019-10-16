using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Server;

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
			int bytesRead = this._stream.EndRead(ar);
			this.totalBuffer += Encoding.ASCII.GetString(this._buffer, 0, bytesRead);

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
		}

		private void HandleSetResistance(string packet)
		{
			int resistancePercentage = int.Parse(TagDecoder.GetValueByTag(Tag.RS, packet));
			Console.WriteLine(resistancePercentage);
			//TODO: Set the resistance of the bike with this integer
		}

		public void Write(string ergoData)
		{
			this._stream.Write(Encoding.ASCII.GetBytes(ergoData), 0, ergoData.Length);
			this._stream.Flush();
		}
	}
}
