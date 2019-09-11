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
            string ergoID = "00472";
            //BLEconnect ergo1 = new BLEconnect(ergoID);
            BLESimulator simulator = new BLESimulator(ergoID);
            simulator.RunSimulator();
            Console.Read();
        }
    }
}
