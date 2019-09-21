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
        private string terrainUuid = "";
       
        public Program(Client client, string tunnelID, VRHelper vRHelper)
        {
            this.function = new Function(client, tunnelID, vRHelper);
            init();
        }
        static void Main(string[] args)
        {
            VRHelper vRHelper = new VRHelper();
            Program program = new Program(vRHelper._client, vRHelper._tunnelID, vRHelper);
        }

        public void init()
        {
            //string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/heightmap.png";
            //Console.WriteLine(function.DynaSceneTerrainAdd(path));
            //Console.WriteLine(function.DynaSceneNodeAdd("terrain", "", null, null, new VRTerrain(true), null, null));

            //CreateFlatTerrain(255,255,1);
            function.DynaSceneReset();
            CreateTerrain();
            CreateTerrainNode();
            AddTexture();
            CreateWaterNode();
            CreateHouseNode();
            Console.Read();
            //

        }

        public void CreateFlatTerrain(int length, int width, int height)
        {
            VRResponse response =function.DynaSceneTerrainAdd(new VRPoint2D(length, width), height);
            Console.WriteLine(response.response.id);
            //Console.WriteLine(response.response.data.uuid);
        }

        public void CreateTerrain()
        {
            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/heightmap.png";
            function.DynaSceneTerrainAdd(path);
            function.DynaSceneNodeAdd("terrain", "", null, null, new VRTerrain(true), null, null);
        }

        public void CreateTerrainNode()
        {
            VRResponse response = function.DynaSceneNodeAdd("terrain", null, new VRTransform(new VRPoint3D(-100, 0, -100), new VRPoint3D(0,0,0), 0.5), null, new VRTerrain(true), null, null);
            this.terrainUuid = response.response.data.data.data.uuid;
        }

        public void CreateWaterNode()
        {
            VRResponse response = function.DynaSceneNodeAdd("water", null, new VRTransform(new VRPoint3D(0, 3, 0), new VRPoint3D(0, 0, 0), 1), null, null, null, new VRWater(new VRPoint2D(400, 400), 1));
        }

        public void CreateHouseNode()
        {
            VRResponse response = function.DynaSceneNodeAdd("house", null, new VRTransform(new VRPoint3D(0, 6, 0), new VRPoint3D(0,0,0), 1), new VRModel(@"data\NetworkEngine\models\houses\set1\citytest1.obj", false, false, null), null, null, null);
        }

        public void AddTexture()
        {
            VRResponse response = function.DynaSceneNodeAddLayer(this.terrainUuid, @"data\NetworkEngine\textures\grass\grass.png", @"data\NetworkEngine\textures\grass\grass.png", 0, 10, 10);
        }
    }
}
