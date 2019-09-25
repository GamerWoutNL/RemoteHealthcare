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

		private void Write(string tag, string message)
        {
            string fullMessage = tag + "#" + message;

            Console.WriteLine("Writing: " + fullMessage);

            _stream.Write(Encoding.ASCII.GetBytes(fullMessage), 0, fullMessage.Length);
            _stream.Flush();
        }

        private void OnRead(IAsyncResult ar)
        {
            Console.WriteLine("Data received");
            //server response handling
        }

		public void Write(string ergoData)
		{
			Console.WriteLine(ergoData);
			Console.Read();
		}
	}
}
