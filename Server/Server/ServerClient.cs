﻿using System;
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
        ID, // Tag of Ergometer / simulator ID
        TS, // Timestamp
        MT //The Message type of the message
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

            while (totalBuffer.Contains("<EOF>"))
            {
                string packet = totalBuffer.Substring(0, totalBuffer.IndexOf("<EOF>") + 5);
                totalBuffer = totalBuffer.Substring(packet.IndexOf("<EOF>") + 5);

                HandlePacket(packet);
            }

            this.stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        private void HandlePacket(string packet)
        {
            // test purposes, ignore the following:
            //string etValue = GetValueByTag(TagErgo.ET, packet);
            //string dtValue = GetValueByTag(TagErgo.DT, packet);
            //string spValue = GetValueByTag(TagErgo.SP, packet);
            //string hrValue = GetValueByTag(TagErgo.HR, packet);
            //string ecValue = GetValueByTag(TagErgo.EC, packet);
            //string icValue = GetValueByTag(TagErgo.IC, packet);
            //string apValue = GetValueByTag(TagErgo.AP, packet);
            //string ipValue = GetValueByTag(TagErgo.IP, packet);
            //string idValue = GetValueByTag(TagErgo.ID, packet);
            //string tsValue = GetValueByTag(TagErgo.TS, packet);

            string mtValue = GetValueByTag(TagErgo.MT, packet);
            string idValue = GetValueByTag(TagErgo.ID, packet);

            // Fastest way to handle the data.
            foreach (TagErgo tag in (TagErgo[])Enum.GetValues(typeof(TagErgo)))
            {
                switch (mtValue)
                {
                    // Default case should be changed to a real case x:, Will the value of mt also be an enum? >> If not should be a string / integer.
                    default:
                        HandleInputErgo(tag, GetValueByTag(tag, packet), idValue);
                        break;
                }
            }
        }

        private void HandleInputErgo(TagErgo tag, string value, string ergoID)
        {
            ClientData clientData;
            clientDatas.TryGetValue(ergoID, out clientData);
            switch (tag)
            {
                case TagErgo.ET:
                    clientData.AddET(value);
                    break;
                case TagErgo.DT:
                    clientData.AddDT(value);
                    break;
                case TagErgo.SP:
                    clientData.AddSP(value);
                    break;
                case TagErgo.HR:
                    clientData.AddHR(value);
                    break;
                case TagErgo.EC:
                    clientData.AddEC(value);
                    break;
                case TagErgo.IC:
                    clientData.AddIC(value);
                    break;
                case TagErgo.AP:
                    clientData.AddAP(value);
                    break;
                case TagErgo.IP:
                    clientData.AddIP(value);
                    break;
                case TagErgo.TS:
                    clientData.AddTS(value);
                    break;
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
            if (tag != TagErgo.EOF)
            {
                string completeTag = $"<{tag.ToString()}>";
                if (packet.Contains(completeTag))
                {
                    Console.WriteLine("Package contains tag!");
                    int startPosition = -1;
                    int endPosition = -1;
                    for (int i = packet.IndexOf(completeTag); i < packet.Length; i++)
                    {
                        char characterAtIndex = packet[i];
                        if (characterAtIndex == '>' && i + 1 < packet.Length)
                        {
                            startPosition = i + 1;
                            break;
                        }
                    }
                    for (int i = startPosition; i < packet.Length; i++)
                    {
                        char characterAtIndex = packet[i];
                        if (characterAtIndex == '<' && i - 1 >= 0)
                        {
                            endPosition = i;
                            break;
                        }
                    }
                    try
                    {
                        string value = packet.Substring(startPosition, endPosition - startPosition);
                        Console.WriteLine($"Found value corresponding with tag : {completeTag} {value}");
                    }
                    catch (ArgumentOutOfRangeException e) { Console.WriteLine("Apparently something went wrong in the GetValueByTag() method located in the ServerClient class. Have you changed code?"); Console.WriteLine(e.ToString()); }
                    Console.WriteLine("String does not contain your searched tag, have you added tags?");
                }
            }
            return String.Empty;
        }
    }
}
