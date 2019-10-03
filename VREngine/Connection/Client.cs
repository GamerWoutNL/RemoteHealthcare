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
		public string tunnelID;
		public List<JObject> Responses { get; }

		public Client()
        {
            this.client = new TcpClient();
			this.buffer = new byte[1024];
			this.totalBuffer = new byte[0];
			this.Responses = new List<JObject>();
		}

        public async Task Connect(string server, int port)
        {
			await client.ConnectAsync(server, port);
			Console.WriteLine($"Connected to {server} on port {port}");
			this.stream = this.client.GetStream();
			stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
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
					//Console.WriteLine(data);
					Responses.Add(json);

					this.totalBuffer = totalBuffer.SubArray(4 + packetSize, totalBuffer.Length - packetSize - 4);
				}
				else
				{
					break;
				}
			}

			stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
		}

		public void Disconnect()
        {
            this.stream.Close();
            this.client.Close();
        }

        private void SendMessage(dynamic message)
        {
			byte[] bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(message));
			this.stream.WriteAsync(BitConverter.GetBytes(bytes.Length), 0, 4).Wait();
			this.stream.WriteAsync(bytes, 0, bytes.Length).Wait();

			Thread.Sleep(50);
		}

		public void OpenTunnel(string _key)
		{
			SendMessage(new { id = "tunnel/create", data = new { session = GetSessionID(), key = _key } });

			JObject response = SearchResponses("tunnel/create");
			JObject data = (JObject)response.GetValue("data");

			this.tunnelID = data.GetValue("id").ToString();
		}

		public void SendTunnel(string _id, dynamic _data)
		{
			SendMessage(new { id = "sent/tunnel", data = new { dest = tunnelID, data = new { id = _id, data = _data } } });
		}

		public JObject SearchResponses(string id)
		{
			Thread.Sleep(1000);
			foreach (JObject json in Responses)
			{
				if (json.GetValue("id").ToString() == id)
				{
					Responses.Remove(json);
					return json;
				}
			}

			return null;
		}

		private string GetSessionID()
		{
			string _id = "session/list";
			SendMessage(new { id = _id });

			JObject json = SearchResponses(_id);

			if (json != null)
			{
				foreach (JObject session in json.GetValue("data"))
				{
					JObject sessionInfo = (JObject)session.GetValue("clientinfo");
					if (sessionInfo.GetValue("user").ToString() == Environment.UserName) {
						return session.GetValue("id").ToString();
					}
				}
			}

			return string.Empty;
		}

		private byte[] Concat(byte[] b1, byte[] b2, int count)
		{
			byte[] r = new byte[b1.Length + count];
			Buffer.BlockCopy(b1, 0, r, 0, b1.Length);
			Buffer.BlockCopy(b2, 0, r, b1.Length, count);
			return r;
		}
	}
}
