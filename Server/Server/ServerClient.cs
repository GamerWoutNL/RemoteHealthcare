using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using Server;
using Server.Data;

namespace Server
{
    class ServerClient
    {
        private TcpClient tcpclient;
		private Server server;
        private NetworkStream stream;
        private byte[] buffer;
        private string totalBuffer;

        public ServerClient(TcpClient client, Server server)
        {
            this.tcpclient = client;
            this.stream = client.GetStream();
			this.server = server;
            this.buffer = new byte[1024];
            this.totalBuffer = string.Empty;

            this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(OnRead), null);
        }

        private void OnRead(IAsyncResult ar)
        {
            int count = stream.EndRead(ar);
			this.totalBuffer += Encrypter.Decrypt(this.buffer.SubArray(0, count), "password123");

            string eof = $"<{Tag.EOF.ToString()}>";
            while (this.totalBuffer.Contains(eof))
            {
                string packet = this.totalBuffer.Substring(0, this.totalBuffer.IndexOf(eof) + eof.Length);
                this.totalBuffer = this.totalBuffer.Substring(packet.IndexOf(eof) + eof.Length);

                HandlePacket(packet);
            }
            this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(OnRead), null);
        }

		public void Write(string message)
		{
			byte[] encrypted = Encrypter.Encrypt(message, "password123");
			this.stream.Write(encrypted, 0, encrypted.Length);
			this.stream.Flush();
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

            string mtValue = TagDecoder.GetValueByTag(Tag.MT, packet);

			if (mtValue == "doctor")
			{
				this.HandleInputDoctor(packet);
			}

            // Fastest way to handle the data.
            foreach (Tag tag in (Tag[])Enum.GetValues(typeof(Tag)))
            {
                switch (mtValue)
                {
					case "data":
						string idValue = TagDecoder.GetValueByTag(Tag.ID, packet);
						string tsValue = TagDecoder.GetValueByTag(Tag.TS, packet);
						this.HandleInputErgo(tag, TagDecoder.GetValueByTag(tag, packet), idValue, tsValue);
						break;
                    // Default case should be changed to a real case x:, Will the value of mt also be an enum? >> If not should be a string / integer.
                }
            }
        }

        private void HandleInputErgo(Tag tag, string value, string ergoID, string timestamp)
        {
            if (value != null)
            {
                ClientData clientData;
                if (!this.server.clientDatas.TryGetValue(ergoID, out clientData))
                {
                    clientData = new ClientData();
					this.server.clientDatas.Add(ergoID, clientData);
                }
                switch (tag) // Timestamp should also be injected below! Adding it seperate is basically useless.
                {
                    case Tag.ET:
                        clientData.AddET(value, timestamp);
                        break;
                    case Tag.DT:
                        clientData.AddDT(value, timestamp);
                        break;
                    case Tag.SP:
                        clientData.AddSP(value, timestamp);
                        break;
                    case Tag.HR:
                        clientData.AddHR(value, timestamp);
                        break;
                    case Tag.EC:
                        clientData.AddEC(value, timestamp);
                        break;
                    case Tag.IC:
                        clientData.AddIC(value, timestamp);
                        break;
                    case Tag.AP:
                        clientData.AddAP(value, timestamp);
                        break;
                    case Tag.IP:
                        clientData.AddIP(value, timestamp);
                        break;
                }
            }
        }

        private void HandleInputDoctor(string packet)
        {
			string action = TagDecoder.GetValueByTag(Tag.AC, packet);

			if (action == "login")
			{
				this.HandleDoctorLogin(packet);
			}
			else if (action == "brake")
			{
				this.HandleEmergencyBrake(packet);
			}
			else if (action == "resistance")
			{
				this.HandleSetResistance(packet);
			}
		}

		private void HandleDoctorLogin(string packet)
		{
			// TODO: Check if doctors password is valid

			Console.WriteLine(packet);
			this.server.doctor = this;
			this.server.streaming = true;

			new Thread(new ThreadStart(this.server.StartStreamingDataToDoctor)).Start();
		}

		private void HandleEmergencyBrake(string packet)
		{
			Console.WriteLine(packet);
			string bikeID = TagDecoder.GetValueByTag(Tag.ID, packet);

			// Packet:
			// <MT>doctor<AC>brake<ID>00472<EOF>
		}

		private void HandleSetResistance(string packet)
		{
			Console.WriteLine(packet);
			throw new NotImplementedException();
		}

        private void HandleInputVR()
        {
            throw new NotImplementedException();
        }
    }
}
