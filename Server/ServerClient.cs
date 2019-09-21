using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Server
{
    class ServerClient
    {
        private TcpClient tcpclient;

        private NetworkStream stream;

        private byte[] buffer = new byte[1024];

        public ServerClient(TcpClient client)
        {
            this.tcpclient = client;
            this.stream = client.GetStream();

            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        private void OnRead(IAsyncResult ar)
        {
            Console.WriteLine("Received Data");
            //check what type of package is received
            //vr or bike or connect?

            int receivedBytes = stream.EndRead(ar);
            string message = Encoding.ASCII.GetString(buffer, 0, receivedBytes);

            string[] data = Regex.Split(message, "#");
            handleMessage(data);
        }

        private void handleMessage(string[] data)
        {
            switch (data[0])
            {
                case "Connect":
                    Console.WriteLine($"User: {data[1]}, has connected");
                    break;
                default:
                    Console.WriteLine("??");
                    break;
            }
        }
    }
}
