using ErgoConnect.BluetoothLowEnergy;
using Server;
using System;
using System.Threading;
using VREngine;

namespace ErgoConnect
{
	/// <summary>
	/// The Program class starts up the application. You can use the simulator to receive data without having physical access to an Ergometer / HR-sensor.
	/// </summary>
	public class Program : ISim
	{
		private readonly Client.Client client;
		private readonly string ergoID;
		private readonly string patientName;
		private readonly string patientNumber;
		public VRHandler VRHandler;
		public BLEConnect ergo;
		public BLESimulator bLESimulator;

		public static void Main(string[] args)
		{
			Console.WriteLine("Patient name: ");
			string patientName = Console.ReadLine();
			Console.WriteLine("Patient number: ");
			string patientNumber = Console.ReadLine();
			Console.WriteLine("Ergo ID: ");
			string ergoId = Console.ReadLine();
			Program program = new Program(ergoId, patientName, patientNumber);
		}

		public Program(string ergoID, string patientName, string patientNumber)
		{
			this.patientName = patientName;
			this.patientNumber = patientNumber;
			this.ergoID = ergoID;
			this.client = new Client.Client();
			this.client.Connect("localhost", 1717, ergoID);
			this.client.Write($"<{Tag.MT.ToString()}>ergo<{Tag.AC.ToString()}>setid<{Tag.ID.ToString()}>{this.ergoID}<{Tag.EOF.ToString()}>");
			this.ergo = new BLEConnect(ergoID, this.client, this, patientName, patientNumber);
			this.client.bleConnect = this.ergo;
			this.ergo.Connect();
			this.VRHandler = new VRHandler(this);
			Console.Read();
			this.client.Disconnect();
		}

		public void Create()
		{
			Console.WriteLine("No connection with bike, using simulator.");
			this.bLESimulator = new BLESimulator(this.ergoID, this.client, this.patientName, this.patientNumber);
			new Thread(new ThreadStart(this.bLESimulator.RunSimulator)).Start();
		}
	}
}
