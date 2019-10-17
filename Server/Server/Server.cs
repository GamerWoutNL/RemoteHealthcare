using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Server.Data;
using System.Security.Cryptography;

namespace Server
{
    public class Server
    {
		private TcpListener listener;
		public List<ServerClient> clients { get; set; }
		public bool streaming { get; set; }
		public ServerClient doctor { get; set; }
		public Dictionary<string, ClientData> clientDatas { get; set; }

		static void Main(string[] args)
        {
            new Server();
			Console.ReadKey();
            
		}

        Server()
        {
			this.clients = new List<ServerClient>();
			this.clientDatas = new Dictionary<string, ClientData>();
            this.listener = new TcpListener(IPAddress.Any, 1717); // Was 1717
            this.listener.Start();
            this.listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
			Console.WriteLine("Listening..");
            clients = new List<ServerClient>();
            clientDatas = new Dictionary<string, ClientData>();
        }

        private void OnConnect(IAsyncResult ar)
        {
            TcpClient newClient = this.listener.EndAcceptTcpClient(ar);
            Console.WriteLine("New client connected");
            this.clients.Add(new ServerClient(newClient, this));

            this.listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
        }

		public void StartStreamingDataToDoctor()
		{
			while (this.streaming)
			{
				foreach (var key in this.clientDatas.Keys)
				{
					string message = $"<{Tag.MT.ToString()}>data<{Tag.ID.ToString()}>{key}{this.clientDatas[key]}";
					this.doctor.Write(message);
				}
				Thread.Sleep(250);
			}
		}

		public void WriteToSpecificErgo(string ergoID, string message)
		{
			foreach (var client in this.clients)
			{
				if (ergoID == client.ergoID)
				{
					client.Write(message);
				}
			}
		}

		public void BroadcastDoctorsMessage(string message)
		{
			foreach (var client in this.clients)
			{
				if (client != this.doctor)
				{
					client.Write(message);
				}
			}
		}
    }
}
