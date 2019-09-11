using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //BLEconnect ergo1 = new BLEconnect(ergoID);
            BLESimulator simulator = new BLESimulator(ergoID);
            simulator.RunSimulator();
            Console.Read();
        }
    }
}
