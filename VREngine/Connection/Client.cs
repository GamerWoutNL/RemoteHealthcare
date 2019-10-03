using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;
using VRCode;

namespace Sprint2VR
{
    public class Client
    {
        private TcpClient client;
        private NetworkStream stream;
		private byte[] buffer;
		private byte[] totalBuffer;

		public Client()
        {
            this.client = new TcpClient();
			this.buffer = new byte[1024];
			this.totalBuffer = new byte[0];
		}

        public async Task Connect(string server, int port)
        {
			await this.client.ConnectAsync(server, port);
			Console.WriteLine($"Connected to {server} on port {port}");
			this.stream = this.client.GetStream();
			this.stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
		}

		private void OnRead(IAsyncResult ar)
		{
			int receivedByte = this.stream.EndRead(ar);
			this.totalBuffer = this.Concat(this.totalBuffer, this.buffer, receivedByte);

			while (totalBuffer.Length >= 4)
			{
				int packetSize = BitConverter.ToInt32(totalBuffer, 0);
				if (totalBuffer.Length >= packetSize + 4)
				{
					string data = Encoding.UTF8.GetString(totalBuffer, 4, packetSize);
					JObject json = (JObject)JsonConvert.DeserializeObject(data);
					Console.WriteLine(data);


					totalBuffer = totalBuffer.SubArray(4 + packetSize, totalBuffer.Length - packetSize - 4);
				}
				else
				{
					break;
				}
			}

			this.stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
		}

		public void Disconnect()
        {
            this.stream.Close();
            this.client.Close();
        }

        public void SendMessage(string message)
        {
			byte[] bytes = Encoding.ASCII.GetBytes(message);
			this.stream.WriteAsync(BitConverter.GetBytes(bytes.Length), 0, 4).Wait();
			this.stream.WriteAsync(bytes, 0, bytes.Length).Wait();
		}

		private byte[] Concat(byte[] b1, byte[] b2, int count)
		{
			byte[] r = new byte[b1.Length + count];
			System.Buffer.BlockCopy(b1, 0, r, 0, b1.Length);
			System.Buffer.BlockCopy(b2, 0, r, b1.Length, count);
			return r;
		}
	}
}
