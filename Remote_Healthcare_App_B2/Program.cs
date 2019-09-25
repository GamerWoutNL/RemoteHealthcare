using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace ErgoConnect
{
    /// <summary>
    /// The Program class starts up the application. You can use the simulator to receive data without having physical access to an Ergometer / HR-sensor.
    /// </summary>
    class Program
    {
        public static void Main(string[] args)
        {
			string ergoID = "00472";

			Client.Client client = new Client.Client(1024);
			client.Connect("localhost", 1717, ergoID);

            BLEconnect ergo1 = new BLEconnect(ergoID, client);
			if(!ergo1.Connect())
			{
				BLESimulator simulator = new BLESimulator(ergoID, client);
				simulator.RunSimulator();
			}

			Console.Read();
        }
    }
}
