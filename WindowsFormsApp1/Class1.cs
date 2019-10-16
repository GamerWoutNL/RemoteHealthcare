using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
    class Connection
    {

        private static NetworkStream stream;
        private byte[] buffer = new byte[1024];

        public static void connect()
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("localhost", 1717);
            stream = tcpClient.GetStream();
        }

        public static void sendMessage(string message)
        {
            stream.Write(Encoding.ASCII.GetBytes(message), 0, message.Length);
            stream.Flush();
        }

        private void OnRead(IAsyncResult ar)
        {
            Console.WriteLine("Received Data");
            //check what type of package is received
            //vr or bike or connect?

            int receivedBytes = stream.EndRead(ar);
            string message = Encoding.ASCII.GetString(buffer, 0, receivedBytes);
        }
    }
}
