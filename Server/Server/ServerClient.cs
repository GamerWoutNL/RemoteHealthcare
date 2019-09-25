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
		ID, // Tag of Ergometer / simulator ID
		TS, // Timestamp
		MT //The Message type of the message
	}

	class ServerClient
	{
		private TcpClient tcpclient;
		private NetworkStream stream;
		private byte[] buffer;
		private string totalBuffer;

		public ServerClient(TcpClient client)
		{
			this.tcpclient = client;
			this.stream = client.GetStream();
			this.buffer = new byte[1024];
			this.totalBuffer = String.Empty;

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
			Console.WriteLine(GetValueByTag(TagErgo.TS, packet));
		}

		private string GetValueByTag(TagErgo tag, string packet)
		{
			try
			{
				int tagPos = packet.IndexOf(tag.ToString());
				int start = 0;
				int end = 0;

				for (int i = tagPos; i < packet.Length; i++)
				{
					if (packet[i] == '>')
					{
						start = i;
					}
					if (packet[i] == '<')
					{
						end = i;
						break;
					}
				}
				return packet.Substring(start, end - start);
			}
			catch (Exception e)
			{

			}
			return "";
		}
	}
}
