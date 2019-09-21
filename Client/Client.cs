using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {

        private static NetworkStream stream;
        private static byte[] buffer = new byte[1024];
        static string totalBuffer = "";


        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 1717);

            stream = client.GetStream();

            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);

            Write("Connect", Environment.UserName);

            Console.ReadKey();
        }

        private static void Write(string tag, string message)
        {
            string fullMessage = tag + "#" + message;

            Console.WriteLine("Writing: " + fullMessage);

            stream.Write(Encoding.ASCII.GetBytes(fullMessage), 0, fullMessage.Length);
            stream.Flush();
        }

        private static void OnRead(IAsyncResult ar)
        {
            Console.WriteLine("Data received");
            //server response handling
        }
    }
}
