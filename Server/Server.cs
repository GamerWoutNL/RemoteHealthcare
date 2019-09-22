using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        static void Main(string[] args)
        {
            new Server();
        }

        TcpListener listener;
        private List<ServerClient> clients = new List<ServerClient>();

        Server()
        {
            listener = new TcpListener(IPAddress.Any, 1717); // Was 1717
            listener.Start();
            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
            Console.ReadKey();
        }

        private void OnConnect(IAsyncResult ar)
        {
            TcpClient newClient = listener.EndAcceptTcpClient(ar);
            Console.WriteLine("Client connected");
            clients.Add(new ServerClient(newClient));

            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
        }
    }
}
