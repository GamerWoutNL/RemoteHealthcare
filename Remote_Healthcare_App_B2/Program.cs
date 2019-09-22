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
            //BLEconnect ergo1 = new BLEconnect("00457");
            BLESimulator simulator = new BLESimulator("00457");
            simulator.RunSimulator();
            Console.Read();
        }
    }
}
