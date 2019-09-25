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
			Client.Client client = new Client.Client(1024);
			client.Connect("localhost", 1717, "00472");



            BLEconnect ergo1 = new BLEconnect("00472", client);
            //BLESimulator simulator = new BLESimulator("00457");
            //simulator.RunSimulator();
            Console.Read();
        }
    }
}
