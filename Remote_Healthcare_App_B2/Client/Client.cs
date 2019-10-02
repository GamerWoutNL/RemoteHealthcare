using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ErgoConnect;

namespace Client
{
    class Client : IClient
    {
		private TcpClient _tcpClient;
        private NetworkStream _stream;
		private byte[] _buffer;
        private string totalBuffer = String.Empty;
		private string _ergoID;

		public Client(int bufferSize)
		{
			this._tcpClient = new TcpClient();
			this._buffer = new byte[bufferSize];
		}

		public void Connect(string server, int port, string ergoID)
		{
			this._tcpClient.Connect(server, port);
			this._stream = this._tcpClient.GetStream();
			this._ergoID = ergoID;
		}

		public void Disconnect()
		{
			this._stream.Close();
			this._tcpClient.Close();
		}

        private void OnRead(IAsyncResult ar)
        {
            Console.WriteLine("Data received");
            //server response handling

        }

		public void Write(string ergoData)
		{
			Console.WriteLine($"Writing: {ergoData}");

			this._stream.Write(Encoding.ASCII.GetBytes(ergoData), 0, ergoData.Length);
			this._stream.Flush();
		}
	}
}
