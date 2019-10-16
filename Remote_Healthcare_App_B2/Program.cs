﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;
using ErgoConnect.BluetoothLowEnergy;

namespace ErgoConnect
{
    /// <summary>
    /// The Program class starts up the application. You can use the simulator to receive data without having physical access to an Ergometer / HR-sensor.
    /// </summary>
    class Program : ISim
    {
		private Client.Client client;
		private string ergoID;
        private string patientName;
        private string patientNumber;

        public static void Main(string[] args)
        {
            string patientName = "Dustin";
            string patientNumber = "81";
			new Program("24517", patientName, patientNumber);
        }

		public Program(string ergoID, string patientName, string patientNumber)
		{
            this.patientName = patientName;
            this.patientNumber = patientNumber;
			this.ergoID = ergoID;
			this.client = new Client.Client(1024);
			client.Connect("localhost", 1717, ergoID);

			BLEConnect ergo = new BLEConnect(ergoID, client, this, patientName, patientNumber);
			ergo.Connect();

            int counter = 0;
            while(true)
            {
                int nr = 0;
                if (nr % 2 == 1) nr = 99;
                else nr = 1;
               Console.ReadLine();
                //    ergo.SendResistance(ergo.ergometerBLE, nr);
                ergo.SetResistance(nr);
                Console.WriteLine("Written resistance on bike");
            }
			Console.Read();
			client.Disconnect();
		}
		public void Create()
		{
			Console.WriteLine("No connection with bike, using simulator.");
			BLESimulator simulator = new BLESimulator(ergoID, client, patientName, patientNumber);
			simulator.RunSimulator();
		}

	}
}
