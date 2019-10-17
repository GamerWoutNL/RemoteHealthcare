﻿using System;
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
    class Server
    {
		private TcpListener listener;
		private List<ServerClient> clients;
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
            listener = new TcpListener(IPAddress.Any, 1717); // Was 1717
            listener.Start();
            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
			Console.WriteLine("Listening..");
        }

        private void OnConnect(IAsyncResult ar)
        {
            TcpClient newClient = listener.EndAcceptTcpClient(ar);
            Console.WriteLine("New client connected");
            clients.Add(new ServerClient(newClient, this));

            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
        }

		public void StartStreamingDataToDoctor()
		{
			while (streaming)
			{
				foreach (var key in clientDatas.Keys)
				{
					string message = $"<MT>data<ID>{key}{clientDatas[key]}";
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
    }
}
