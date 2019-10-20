using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
	public class Server
	{
		private readonly TcpListener listener;
		public List<ServerClient> clients { get; set; }
		public bool streaming { get; set; }
		public ServerClient doctor { get; set; }
		public Dictionary<string, ClientData> clientDatas { get; set; }

		private static void Main(string[] args)
		{
			new Server();
			Console.ReadKey();
		}

		public Server()
		{
			this.clients = new List<ServerClient>();
			this.clientDatas = new Dictionary<string, ClientData>();
			this.listener = new TcpListener(IPAddress.Any, 1717); // Was 1717
			this.listener.Start();

			this.listener.BeginAcceptTcpClient(new AsyncCallback(this.OnConnect), null);
			Console.WriteLine("Listening..");
		}

		private void OnConnect(IAsyncResult ar)
		{
			TcpClient newClient = this.listener.EndAcceptTcpClient(ar);
			this.clients.Add(new ServerClient(newClient, this));
			Console.WriteLine("New client connected");

			this.listener.BeginAcceptTcpClient(new AsyncCallback(this.OnConnect), null);
		}

		public void StartStreamingDataToDoctor()
		{
			while (this.streaming)
			{
				foreach (string key in this.clientDatas.Keys)
				{
					string message = $"<{Tag.MT.ToString()}>data<{Tag.ID.ToString()}>{key}{this.clientDatas[key]}";
					this.doctor.Write(message);
				}
				Thread.Sleep(250);
			}
		}

		public void WriteToSpecificErgo(string ergoID, string message)
		{
			foreach (ServerClient client in this.clients)
			{
				if (ergoID == client.ergoID)
				{
					client.Write(message);
				}
			}
		}

		public void BroadcastDoctorsMessage(string message)
		{
			foreach (ServerClient client in this.clients)
			{
				if (client != this.doctor)
				{
					client.Write(message);
				}
			}
		}
	}
}
