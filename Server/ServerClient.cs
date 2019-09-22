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

        Dictionary<string, List<string[]>> patients = new Dictionary<string, List<string[]>>();

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
            Console.WriteLine(data[0]);
            handleMessage(data);
        }

        private void handleMessage(string[] data)
        {
            
            switch (data[0])
            {
                case "Connect":
                    Console.WriteLine($"User: {data[1]}, has connected");
                    patients.Add(data[1], new List<string[]>());
                    break;
                case "Datapackage":
                    Console.WriteLine($"Data package recieved from: {data[1]}");
                    HandleDataMessage(data);

                    break;
                default:
                    Console.WriteLine($"Tag: {data[0]} not recognized!");
                    break;
            }
        }

        private void HandleDataMessage(string[] data)
        {
            switch (data[2])
            {
                case "BikeData16":
                    patients[data[1]].Add(data);
                    Console.WriteLine(patients[data[1]].ToString());
                    break;
                case "BikeData25":
                    patients[data[1]].Add(data);
                    Console.WriteLine(patients[data[1]].ToString());
                    break;
                default:
                    Console.WriteLine("Error, type not recognized");
                    break;
            }
        }
    }
}
