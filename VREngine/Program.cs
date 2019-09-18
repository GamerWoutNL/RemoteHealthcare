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

            VRHelper vRHelper = new VRHelper();
            Program program = new Program(vRHelper._client, vRHelper._tunnelID, vRHelper);
            Console.ReadLine();
            program.CreateFlatTerrain(50, 50, 1);
            Console.ReadLine();
            program.CreateTerrainNode();
        }

        public void CreateFlatTerrain(int length, int width, int height)
        {
            int[] heightmap = new int[length * width];
            for (int i = 0; i < length * width; i++)
                heightmap[i] = height;
            VRResponse response =function.dynaSceneTerrainAdd(new Sprint2VR.VR.Components.VRPositionXY(length, width), heightmap);
        }

        public void CreateTerrainNode()
        {
            List<VRComponent> vRComponents = new List<VRComponent>();
            vRComponents.Add(new VRTerrain(true));
            VRResponse response = function.dynaSceneNodeAdd("terrain", "", vRComponents);
        }
    }
}
