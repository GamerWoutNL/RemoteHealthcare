using System;
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

        public static void Main(string[] args)
        {
			new Program("01249");
        }

		public Program(string ergoID)
		{
			this.ergoID = ergoID;
			this.client = new Client.Client();
			client.Connect("localhost", 1717, ergoID);

			BLEConnect ergo = new BLEConnect(ergoID, client, this);
			ergo.Connect();

			Console.Read();
			client.Disconnect();
		}
		public void Create()
		{
			Console.WriteLine("No connection with bike, using simulator.");
			BLESimulator simulator = new BLESimulator(ergoID, client);
			simulator.RunSimulator();
		}

	}
}
