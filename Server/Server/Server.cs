using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.Data;
using System.Security.Cryptography;

namespace Server
{
    class Server
    {
		private TcpListener listener;
		private List<ServerClient> clients = new List<ServerClient>();

		static void Main(string[] args)
        {
			//new Server();

			string test = "dikkigheid kent geen tijd";

			byte[] encrypted = Encrypter.Encrypt(test, "dikkig");
			Console.WriteLine(Encrypter.Decrypt(encrypted, "dikkig"));


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
            clients.Add(new ServerClient(newClient));

            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
        }
    }
}
