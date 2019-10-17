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
        private TcpClient client;
		private Server server;
        private NetworkStream stream;
        private byte[] buffer;
        private string totalBuffer;
        private Dictionary<String, ClientData> clientDatas; // Should use ErgoID as a key.
        private Dictionary<String, String> boundData; // patientNumber = key, ErgoID = value
		public string ergoID { get; set; }

        public ServerClient(TcpClient client)
        {
            this.client = client;
            this.stream = this.client.GetStream();
			this.server = server;
            this.buffer = new byte[1024];
            this.totalBuffer = string.Empty;
			this.ergoID = string.Empty;

            this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(OnRead), null);
            this.clientDatas = new Dictionary<String, ClientData>();
        }

        private void OnRead(IAsyncResult ar)
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
						this.HandleInputErgo(tag, TagDecoder.GetValueByTag(tag, packet), idValue, tsValue);
						break;
                    // Default case should be changed to a real case x:, Will the value of mt also be an enum? >> If not should be a string / integer.
                    default:
                        HandleInputErgo(tag, GetValueByTag(tag, packet), idValue, tsValue, pnuValue);
                        break;
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

		private void HandleInputErgo(Tag tag, string value, string ergoID, string timestamp)
        {
            if (value != null)
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
                    case TagErgo.PNA:
                        clientData.SetPNA(value);
                        break;
                    case TagErgo.PNU:
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
			string bikeID = TagDecoder.GetValueByTag(Tag.ID, packet);
			this.server.WriteToSpecificErgo(bikeID, $"<{Tag.MT.ToString()}>ergo<{Tag.AC.ToString()}>brake<{Tag.EOF.ToString()}>");
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
    }
}
