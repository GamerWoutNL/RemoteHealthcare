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
using System.Net;
using System.IO;


namespace Server
{
    public class ServerClient
    {
        private TcpClient client;
		private Server server;
        private NetworkStream stream;
        private byte[] buffer;
        private string totalBuffer;
        private Dictionary<String, String> boundData; // patientNumber = key, ErgoID = value
		public string ergoID { get; set; }
        public bool running = true;

        public ServerClient(TcpClient client, Server server)
        {
            this.client = client;
            this.stream = this.client.GetStream();
			this.server = server;
            this.buffer = new byte[1024];
            this.totalBuffer = string.Empty;
			this.ergoID = string.Empty;

			this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(OnRead), null);
        }

        private void OnRead(IAsyncResult ar)
        {
			try
			{
				int count = this.stream.EndRead(ar);
				this.totalBuffer += Encrypter.Decrypt(this.buffer.SubArray(0, count), "password123");

				string eof = $"<{Tag.EOF.ToString()}>";
				while (this.totalBuffer.Contains(eof))
				{
					string packet = this.totalBuffer.Substring(0, this.totalBuffer.IndexOf(eof) + eof.Length);
					this.totalBuffer = this.totalBuffer.Substring(packet.IndexOf(eof) + eof.Length);

					this.HandlePacket(packet);
				}
				this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(OnRead), null);
			}
			catch (IOException)
			{
				this.stream.Close();
				this.client.Close();
				this.server.clients.Remove(this);
				Console.WriteLine("Client disconnected");
			}
		}

		public void Write(string message)
		{
			byte[] encrypted = Encrypter.Encrypt(message, "password123");
			this.stream.Write(encrypted, 0, encrypted.Length);
			this.stream.Flush();
		}

		private void HandlePacket(string packet)
		{
			//Console.WriteLine(packet); return;

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
			else if (mtValue == "ergo")
			{
				this.HandleInputErgo(packet);
			}

			// Fastest way to handle the data.
			foreach (Tag tag in (Tag[])Enum.GetValues(typeof(Tag)))
			{
				switch (mtValue)
				{
					case "data":
						string idValue = TagDecoder.GetValueByTag(Tag.ID, packet);
						string tsValue = TagDecoder.GetValueByTag(Tag.TS, packet);
						string pnuValue = TagDecoder.GetValueByTag(Tag.PNU, packet);
						this.HandleInputErgo(tag, TagDecoder.GetValueByTag(tag, packet), idValue, tsValue, pnuValue);
						break;
					// Default case should be changed to a real case x:, Will the value of mt also be an enum? >> If not should be a string / integer.
				}
			}
		}

		private void HandleInputErgo(string packet)
		{
			string action = TagDecoder.GetValueByTag(Tag.AC, packet);
			if (action == "setid")
			{
				this.HandleSetErgoID(packet);
			}
		}

		private void HandleSetErgoID(string packet)
		{
			this.ergoID = TagDecoder.GetValueByTag(Tag.ID, packet);
		}

		private void HandleInputErgo(Tag tag, string value, string ergoID, string timestamp, string pnu)
        {
            if (value != null)
            {
                ClientData clientData;
                if (!this.server.clientDatas.TryGetValue(ergoID, out clientData))
                {
                    clientData = new ClientData();
                    this.server.clientDatas.Add(ergoID, clientData);
                    //if (pnu != null)
                    //    boundData.Add(pnu, ergoID);
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
                    case Tag.PNA:
                        clientData.SetPNA(value);
                        break;
                    case Tag.PNU:
                        clientData.SetPNU(value);
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
			else if (action == "emergencybrake")
			{
				this.HandleEmergencyBrake(packet);
			}
			else if (action == "brake")
			{
				this.HandleSessionStop(packet);
			}
			else if (action == "resistance")
			{
				this.HandleSetResistance(packet);
			}
			else if (action == "message")
			{
				this.HandleDoctorMessage(packet);
			}
		}

		private void HandleSessionStop(string packet)
		{
			string ergoID = TagDecoder.GetValueByTag(Tag.ID, packet);
			this.server.WriteToSpecificErgo(ergoID, $"<{Tag.MT.ToString()}>ergo<{Tag.AC.ToString()}>brake<{Tag.EOF.ToString()}>");
		}

		private void HandleDoctorMessage(string packet)
		{
			string id = TagDecoder.GetValueByTag(Tag.ID, packet);
			string message = TagDecoder.GetValueByTag(Tag.DM, packet);
			if (id == "all")
			{
				this.server.BroadcastDoctorsMessage($"<{Tag.MT.ToString()}>ergo<{Tag.AC.ToString()}>message<{Tag.DM.ToString()}>{message}<{Tag.EOF.ToString()}>");
			}
			else
			{
				this.server.WriteToSpecificErgo(id, $"<{Tag.MT.ToString()}>ergo<{Tag.AC.ToString()}>message<{Tag.DM.ToString()}>{message}<{Tag.EOF.ToString()}>");
			}
		}

		private void HandleDoctorLogin(string packet)
		{
			// TODO: Check if doctors password is valid
			string username = TagDecoder.GetValueByTag(Tag.UN, packet);
			string password = TagDecoder.GetValueByTag(Tag.PW, packet);

            if (FileWriter.checkPassword(username, password))
            {
                this.server.doctor = this;
                this.server.streaming = true;

                this.Write($"<{Tag.LR.ToString()}>true<{Tag.EOF.ToString()}>");
                new Thread(new ThreadStart(this.server.StartStreamingDataToDoctor)).Start();
            }

			
		}

		private void HandleEmergencyBrake(string packet)
		{
			string bikeID = TagDecoder.GetValueByTag(Tag.ID, packet);
			this.server.WriteToSpecificErgo(bikeID, $"<{Tag.MT.ToString()}>ergo<{Tag.AC.ToString()}>emergencybrake<{Tag.EOF.ToString()}>");
		}

		private void HandleSetResistance(string packet)
		{
			string bikeID = TagDecoder.GetValueByTag(Tag.ID, packet);
			string resistance = TagDecoder.GetValueByTag(Tag.SR, packet);

			this.server.WriteToSpecificErgo(bikeID, $"<{Tag.MT.ToString()}>ergo<{Tag.AC.ToString()}>resistance<{Tag.SR}>{resistance}<{Tag.EOF.ToString()}>");
		}

		private void HandleInputVR()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            running = false;
        }
    }
}
