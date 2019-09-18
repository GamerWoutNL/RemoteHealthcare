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

namespace Sprint2VR
{
    public class Client
    {
        private TcpClient tcpClient;
        private NetworkStream stream;

        public Client()
        {
            this.tcpClient = new TcpClient();
        }

        public void Connect(string server, int port)
        {
            this.tcpClient.Connect(server, port);
            this.stream = this.tcpClient.GetStream();
        }

        public void Disconnect()
        {
            this.stream.Close();
            this.tcpClient.Close();
        }

        public void WriteMessage(dynamic message)
        {
            Console.WriteLine("Send: "+JsonConvert.SerializeObject(message));
            byte[] packet = this.GetPrefixedMessage(JsonConvert.SerializeObject(message));
            this.stream.Write(packet, 0, packet.Length);
            this.stream.Flush();
        }

        public JObject ReadMessage()
        {
            byte[] prefixBuffer = new byte[4];
            this.stream.Read(prefixBuffer, 0, prefixBuffer.Length);

            long length = (((((prefixBuffer[3] << 8) | prefixBuffer[2]) << 8) | prefixBuffer[1]) << 8) | prefixBuffer[0];

            byte[] dataBuffer = new byte[length];
            this.stream.Read(dataBuffer, 0, dataBuffer.Length);
            this.stream.Flush();

            return this.StringToJson(Encoding.UTF8.GetString(dataBuffer));
        }

        private byte[] GetPrefixedMessage(string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            byte[] prefix = BitConverter.GetBytes(data.Length);

            byte[] final = new byte[4 + data.Length];

            prefix.CopyTo(final, 0);
            data.CopyTo(final, 4);

            return final;
        }

        private JObject StringToJson(string data)
        {
            return (JObject)JsonConvert.DeserializeObject(data);
        }
    }
}
