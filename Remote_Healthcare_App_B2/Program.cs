using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;
using ErgoConnect.BluetoothLowEnergy;
using Server;
using VREngine;
using System.Threading;

namespace ErgoConnect
{
    /// <summary>
    /// The Program class starts up the application. You can use the simulator to receive data without having physical access to an Ergometer / HR-sensor.
    /// </summary>
    public class Program : ISim
    {
		private Client.Client client;
		private string ergoID;
        private string patientName;
        private string patientNumber;
        private VRHandler VRHandler;

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
			client.Connect("localhost", 1717, ergoID);
			client.Write($"<{Tag.MT.ToString()}>ergo<{Tag.AC.ToString()}>setid<{Tag.ID.ToString()}>{this.ergoID}<{Tag.PNA.ToString()}>{patientName}<{Tag.PNU.ToString()}>{patientNumber}<{Tag.EOF.ToString()}>");


            BLEConnect ergo = new BLEConnect(ergoID, client, this, patientName, patientNumber);
			client.bleConnect = ergo;
			ergo.Connect();

            //int counter = 0;
            //while(true)
            //{
            //    int nr = 0;
            //    if (nr % 2 == 1) nr = 99;
            //    else nr = 1;
            //   Console.ReadLine();
            //    //    ergo.SendResistance(ergo.ergometerBLE, nr);
            //    ergo.SetResistance(nr);
            //    Console.WriteLine("Written resistance on bike");
            //}
            this.VRHandler = new VRHandler(this);
            Console.Read();
			client.Disconnect();
		}

        public void Create()
		{
			Console.WriteLine("No connection with bike, using simulator.");
			BLESimulator simulator = new BLESimulator(ergoID, client, patientName, patientNumber);

            new Thread(new ThreadStart(simulator.RunSimulator)).Start();
		}

	}
}
