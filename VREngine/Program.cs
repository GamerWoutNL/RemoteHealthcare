using Sprint2VR;
using Sprint2VR.VR;
using Sprint2VR.VR.Additional;
using Sprint2VR.VR.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCode
{
    class Program
    {
        private Function function;
       
        public Program(Client client, string tunnelID, VRHelper vRHelper)
        {
            this.function = new Function(client, tunnelID, vRHelper);
            
        }
        static void Main(string[] args)
        {

            //VRHelper vRHelper = new VRHelper();
            //Program program = new Program(vRHelper._client, vRHelper._tunnelID, vRHelper);
         
        }
    }
}
