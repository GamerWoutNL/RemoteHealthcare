using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace DoktorApp.Communication
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
		MT   //The Message type of the message
	}

	public class Client
	{
		private TcpClient client;
		private NetworkStream stream;
		private byte[] buffer;
		private string totalBuffer;

		public Client()
		{
			this.client = new TcpClient();
			this.stream = client.GetStream();
			this.buffer = new byte[1024];
			this.totalBuffer = string.Empty;

			this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(OnRead), null);
		}

		private void OnRead(IAsyncResult ar)
		{
			int bytesRead = this.stream.EndRead(ar);
			this.totalBuffer += Encoding.ASCII.GetString(this.buffer, 0, bytesRead);

			string eof = $"<{TagErgo.EOF.ToString()}>";

			while (totalBuffer.Contains(eof))
			{
				string packet = totalBuffer.Substring(0, totalBuffer.IndexOf(eof) + 5);
				totalBuffer = totalBuffer.Substring(packet.IndexOf(eof) + 5);

				HandlePacket(packet);
			}

			this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(OnRead), null);
		}

		private void HandlePacket(string packet)
		{
			Console.WriteLine(packet);
		}

		public void Write(string message)
		{
			this.stream.Write(Encoding.ASCII.GetBytes(message), 0, message.Length);
			this.stream.Flush();
		}

		public void Connect(string server, int port)
		{
			this.client.Connect(server, port);
			this.stream = this.client.GetStream();
		}

		public void Disconnect()
		{
			this.stream.Close();
			this.client.Close();
		}
	}
}
