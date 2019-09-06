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
            BLEconnect bike1 = new BLEconnect("00472");
            //Simulator simulator = new Simulator();
            Console.Read();
        }
    }
}
