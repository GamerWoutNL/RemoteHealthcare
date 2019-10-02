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

namespace Sprint2VR
{
    public class Client
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
		private byte[] buffer;
		private string totalBuffer;

		public Client()
        {
            this.tcpClient = new TcpClient();
			this.buffer = new byte[1024];
			this.totalBuffer = "";
		}

        public void Connect(string server, int port)
        {
            this.tcpClient.Connect(server, port);
			this.stream = this.tcpClient.GetStream();
			this.stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
		}

		private void OnRead(IAsyncResult ar)
		{
			try
			{
				int rc = stream.EndRead(ar);
				totalBuffer = concat(totalBuffer, buffer, rc);
			}
			catch (System.IO.IOException)
			{
				Application.Exit();
				return;
			}
			while (totalBuffer.Length >= 4)
			{
				int packetSize = BitConverter.ToInt32(totalBuffer, 0);
				if (totalBuffer.Length >= packetSize + 4)
				{
					string data = Encoding.UTF8.GetString(totalBuffer, 4, packetSize);
					dynamic json = JsonConvert.DeserializeObject(data);
					Console.WriteLine("Got a packet " + json.id);

					string id = json.id;
					if (callbacks.ContainsKey(id))
						callbacks[id](json.data);

					totalBuffer = totalBuffer.SubArray(4 + packetSize, totalBuffer.Length - packetSize - 4);
				}
				else
					break;
			}
			stream.BeginRead(buffer, 0, 1024, onRead, null);
		}


		public void Disconnect()
        {
            this.stream.Close();
            this.tcpClient.Close();
        }

        public void WriteMessage(dynamic message)
        {
            Console.WriteLine("Send in client: " + JsonConvert.SerializeObject(message));
            byte[] packet = this.GetPrefixedMessage(JsonConvert.SerializeObject(message));
            this.stream.Write(packet, 0, packet.Length);
            this.stream.Flush();
        }

		public JObject ReadMessage()
		{
			byte[] prefixBuffer = new byte[4];
			this.stream.Read(prefixBuffer, 0, prefixBuffer.Length);

			long length = (((((prefixBuffer[3] << 8) | prefixBuffer[2]) << 8) | prefixBuffer[1]) << 8) | prefixBuffer[0];

			byte[] dataBuffer = new byte[length];
			this.stream.Read(dataBuffer, 0, dataBuffer.Length);
			this.stream.Flush();

			return this.StringToJson(Encoding.UTF8.GetString(dataBuffer));
		}

		private byte[] GetPrefixedMessage(string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            byte[] prefix = BitConverter.GetBytes(data.Length);

            byte[] final = new byte[4 + data.Length];

            prefix.CopyTo(final, 0);
            data.CopyTo(final, 4);

            return final;
        }

        private JObject StringToJson(string data)
        {
            return (JObject)JsonConvert.DeserializeObject(data);
        }
    }
}
