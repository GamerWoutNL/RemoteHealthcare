using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    class Program
    {
        public static void Main(string[] args)
        {
            //BLEconnect ergo1 = new BLEconnect("00472");
            BLESimulator simulator = new BLESimulator("00472");
            simulator.RunSimulator();
            Console.Read();
        }
    }
}
