using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Server
{
    public enum TagErgo
    {
        // Page 16
        ET, // Elapsed time
        DT, // Distance travelled
        SP, // Speed
        HR, // Heartrate

        // Page 25
        EC, // Event count
        IC, // Instanteous cadence
        AP, // Accumulated power
        IP, // Instanteous power

        // Extra
        EOF, // End Of File
        ID,  // Tag of Ergometer / simulator ID
        TS,  // Timestamp
        MT,   //The Message type of the message
        PNA, // The patient name
        PNU // The patient number
    }

    public enum TagDoctor
    {

    }

    public enum TagVR
    {

    }

    class ServerClient
    {
        private TcpClient tcpclient;
        private NetworkStream stream;
        private byte[] buffer;
        private string totalBuffer;
        private Dictionary<String, ClientData> clientDatas; // Should use ErgoID as a key.
        private Dictionary<String, String> boundData; // patientNumber = key, ErgoID = value

        public ServerClient(TcpClient client)
        {
            this.tcpclient = client;
            this.stream = client.GetStream();
            this.buffer = new byte[1024];
            this.totalBuffer = String.Empty;
            this.clientDatas = new Dictionary<String, ClientData>();
            this.stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        private void OnRead(IAsyncResult ar)
        {
            int receivedBytes = stream.EndRead(ar);
            this.totalBuffer += Encoding.ASCII.GetString(buffer, 0, receivedBytes);
            string eof = $"<{TagErgo.EOF.ToString()}>";

            while (totalBuffer.Contains(eof))
            {
                string packet = totalBuffer.Substring(0, totalBuffer.IndexOf(eof) + 5);
                totalBuffer = totalBuffer.Substring(packet.IndexOf(eof) + 5);

                HandlePacket(packet);
            }
            this.stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        private void HandlePacket(string packet)
        {
            string mtValue = GetValueByTag(TagErgo.MT, packet);
            string idValue = GetValueByTag(TagErgo.ID, packet);
            string tsValue = GetValueByTag(TagErgo.TS, packet);
            string pnuValue = GetValueByTag(TagErgo.PNU, packet);

            // Fastest way to handle the data.
            foreach (TagErgo tag in (TagErgo[])Enum.GetValues(typeof(TagErgo)))
                switch (mtValue)
                {
                    // Default case should be changed to a real case x:, Will the value of mt also be an enum? >> If not should be a string / integer.
                    default:
                        HandleInputErgo(tag, GetValueByTag(tag, packet), idValue, tsValue, pnuValue);
                        break;
                }
        }

        private void HandleInputErgo(TagErgo tag, string value, string ergoID, string timestamp, string pnu)
        {
            if (value != String.Empty)
            {
                ClientData clientData;
                if (!clientDatas.TryGetValue(ergoID, out clientData))
                {
                    clientData = new ClientData();
                    clientDatas.Add(ergoID, clientData);
                    //if (pnu != null)
                    //    boundData.Add(pnu, ergoID);
                }
                switch (tag) // Timestamp should also be injected below! Adding it seperate is basically useless.
                {
                    case TagErgo.ET:
                        clientData.AddET(value, timestamp);
                        break;
                    case TagErgo.DT:
                        clientData.AddDT(value, timestamp);
                        break;
                    case TagErgo.SP:
                        clientData.AddSP(value, timestamp);
                        break;
                    case TagErgo.HR:
                        clientData.AddHR(value, timestamp);
                        break;
                    case TagErgo.EC:
                        clientData.AddEC(value, timestamp);
                        break;
                    case TagErgo.IC:
                        clientData.AddIC(value, timestamp);
                        break;
                    case TagErgo.AP:
                        clientData.AddAP(value, timestamp);
                        break;
                    case TagErgo.IP:
                        clientData.AddIP(value, timestamp);
                        break;
                    case TagErgo.PNA:
                        clientData.SetPNA(value);
                        break;
                    case TagErgo.PNU:
                        clientData.SetPNU(value);
                        break;
                }
                Console.WriteLine(clientData.ToString());
            }
        }

        private void HandleInputDoktor()
        {
            throw new NotImplementedException();
        }

        private void HandleInputVR()
        {
            throw new NotImplementedException();
        }

        private string GetValueByTag(TagErgo tag, string packet)
        {
            char openTag = '<';
            char closeTag = '>';
            if (tag != TagErgo.EOF)
            {
                string completeTag = $"{openTag}{tag.ToString()}{closeTag}";
                if (packet.Contains(completeTag))
                {
                    int startPosition = -1;
                    int endPosition = -1;
                    for (int i = packet.IndexOf(completeTag); i < packet.Length; i++)
                    {
                        char characterAtIndex = packet[i];
                        if (characterAtIndex == closeTag && i + 1 < packet.Length)
                        {
                            startPosition = i + 1;
                            break;
                        }
                    }
                    for (int i = startPosition; i < packet.Length; i++)
                    {
                        char characterAtIndex = packet[i];
                        if (characterAtIndex == openTag && i - 1 >= 0)
                        {
                            endPosition = i;
                            break;
                        }
                    }
                    try
                    {
                        string value = packet.Substring(startPosition, endPosition - startPosition);
                        return value;
                    }
                    catch (ArgumentOutOfRangeException e) { Console.WriteLine($"Apparently something went wrong in the GetValueByTag() method located in the ServerClient class. Have you changed any code? {e.ToString()}"); }
                }
            }
            return String.Empty;
        }
    }
}
