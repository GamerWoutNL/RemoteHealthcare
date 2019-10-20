using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sprint2VR.VR;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VRCode;

namespace Sprint2VR
{
	public class VRClient
	{
		private readonly TcpClient client;
		private NetworkStream stream;
		private readonly byte[] buffer;
		private byte[] totalBuffer;
		private string tunnelID;
		public List<JObject> Responses { get; set; }

		private static readonly object lockingObject = new object();

		public VRClient()
		{
			this.client = new TcpClient();
			this.buffer = new byte[1024];
			this.totalBuffer = new byte[0];
			this.Responses = new List<JObject>();
		}

		public async Task Connect(string server, int port)
		{
			await this.client.ConnectAsync(server, port);
			Console.WriteLine($"Connected to {server} on port {port}");
			this.stream = this.client.GetStream();
			this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(this.OnRead), null);
		}

		private void OnRead(IAsyncResult ar)
		{
			int receivedByte = this.stream.EndRead(ar);
			this.totalBuffer = this.Concat(this.totalBuffer, this.buffer, receivedByte);

			while (this.totalBuffer.Length >= 4)
			{
				int packetSize = BitConverter.ToInt32(this.totalBuffer, 0);
				if (this.totalBuffer.Length >= packetSize + 4)
				{
					string data = Encoding.UTF8.GetString(this.totalBuffer, 4, packetSize);
					JObject json = (JObject)JsonConvert.DeserializeObject(data);

					lock (lockingObject)
					{
						this.Responses.Add(json);
					}

					this.totalBuffer = this.totalBuffer.SubArray(4 + packetSize, this.totalBuffer.Length - packetSize - 4);
				}
				else
				{
					break;
				}
			}

			this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(this.OnRead), null);
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
			this.SendMessage(new { id = IDOperations.tunnelCreate, data = new { session = this.GetSessionID(), key = _key } });

			JObject response = this.SearchResponses(IDOperations.tunnelCreate);
			JObject data = (JObject)response.GetValue("data");

			this.tunnelID = data.GetValue("id").ToString();
		}

		public void SendTunnel(string _id, dynamic _data)
		{
			this.SendMessage(new { id = IDOperations.tunnelSend, data = new { dest = this.tunnelID, data = new { id = _id, data = _data } } });
		}

		public JObject SearchResponses(string id)
		{
			for (int i = 0; i < 10000; i++)
			{
				for (int j = this.Responses.Count - 1; j >= 0; j--)
				{
					JObject json = this.Responses[j];

					if (json.GetValue("id").ToString() == id)
					{
						this.Responses.Remove(json);
						return json;
					}

					try
					{
						JObject data1 = (JObject)json.GetValue("data");
						JObject data2 = (JObject)data1.GetValue("data");

						if (data2.GetValue("id").ToString() == id)
						{
							this.Responses.Remove(json);
							return json;
						}
					}
					catch (Exception)
					{

					}

				}
				Thread.Sleep(1);
			}
			return null;
		}

		private string GetSessionID()
		{
			this.SendMessage(new { id = IDOperations.sessionList });

			JObject json = this.SearchResponses(IDOperations.sessionList);

			if (json != null)
			{
				foreach (JObject session in json.GetValue("data"))
				{
					JObject sessionInfo = (JObject)session.GetValue("clientinfo");
					Console.WriteLine(sessionInfo.GetValue("user"));
					if (sessionInfo.GetValue("user").ToString() == Environment.UserName)
					{ // was Environment.Username // Kan CavePC_1 zijn
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
