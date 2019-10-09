using Sprint2VR;
using Sprint2VR.VR.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRCode;
using Sprint2VR.VR;
using Newtonsoft.Json.Linq;

namespace VREngine
{
    class VRHandler
    {
        private Client client;
        private Function function;

        public VRHandler()
        {
            this.client = new Client();
            client.Connect("145.48.6.10", 6666);
            client.OpenTunnel("muffins");

            this.function = new Function(client);
            this.Init();
        }

        static void Main(string[] args)
        {
            new VRHandler();

            Console.Read();
        }

        private void Init()
        {
            function.DynaSceneReset();
            CreateEnvironment();
            FindVRParts();
            FindEverything();
            while (true)
            {
                FindVRParts();

            }

        }

        //Organized code start:
        //Code to create the environment:
        public void CreateEnvironment()
        {
            //Begin of terrain heightmap + texture
            bool doHeightmap = false;
            if (doHeightmap)
            {
                string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/heightmap.png";
                function.DynaSceneTerrainAdd(path);
                function.DynaSceneNodeAdd("terrain", null, new VRTransform(new VRPoint3D(-100, 0, -100), new VRPoint3D(0, 0, 0), 0.5), null, new VRTerrain(true), null, null);
                dynamic responseTerrainNode = client.SearchResponses(IDOperations.sceneNodeAdd);
                Console.WriteLine(responseTerrainNode);
                string terrainUuid = responseTerrainNode.data.data.data.uuid;
                function.DynaSceneNodeAddLayer(terrainUuid, @"data\NetworkEngine\textures\grass\grass.png", @"data\NetworkEngine\textures\grass\grass.png", 0, 10, 10);
            }
            //End of terrain heightmap + texture

            //Begin of create water
            function.DynaSceneNodeAdd("water", null, new VRTransform(new VRPoint3D(0, 13, 0), new VRPoint3D(0, 0, 0), 1), null, null, null, new VRWater(new VRPoint2D(1000, 1000), 5));
            dynamic responseWaterNode = client.SearchResponses(IDOperations.sceneNodeAdd);
            string waterUuid = responseWaterNode.data.data.data.uuid;
            Console.WriteLine(responseWaterNode);
            //End of create water

            //Begin of create city
            function.DynaSceneNodeAdd("city", null, new VRTransform(new VRPoint3D(0, 6, 0), new VRPoint3D(0, 0, 0), 1), new VRModel(@"data\NetworkEngine\models\houses\set1\citytest1.obj", false, false, null), null, null, null);
            dynamic responseCityNode = client.SearchResponses(IDOperations.sceneNodeAdd);
            string cityUuid = responseCityNode.data.data.data.uuid;
            Console.WriteLine(responseCityNode);
            //End of create city

            //Begin of create skybox
            string skyboxFolder = "spires";
            string skyboxName = "spires";
            string skyboxExtension = "png";
            VRSkybox vRSkybox = new VRSkybox();
            vRSkybox.SetCustomSkybox($"data/NetworkEngine/textures/SkyBoxes/{skyboxFolder}/{skyboxName}_rt.{skyboxExtension}", $"data/NetworkEngine/textures/SkyBoxes/{skyboxFolder}/{skyboxName}_lf.{skyboxExtension}", $"data/NetworkEngine/textures/SkyBoxes/{skyboxFolder}/{skyboxName}_up.{skyboxExtension}", $"data/NetworkEngine/textures/SkyBoxes/{skyboxFolder}/{skyboxName}_dn.{skyboxExtension}", $"data/NetworkEngine/textures/SkyBoxes/{skyboxFolder}/{skyboxName}_bk.{skyboxExtension}", $"data/NetworkEngine/textures/SkyBoxes/{skyboxFolder}/{skyboxName}_ft.{skyboxExtension}");
            function.DynaSceneSkyboxUpdate(vRSkybox);
            //End of create skybox

            //Find standard pane, and DELETE it!
            function.DynaSceneNodeFind("GroundPlane");
            dynamic responseGroundplane = client.SearchResponses(IDOperations.sceneNodeFind);
            string uuid = responseGroundplane.data.data.uuid;
            Console.WriteLine("Groundplane info:");
            Console.WriteLine(responseGroundplane);
            //--> Delete it
            function.DynaSceneNodeDelete(uuid);
            //End of find standard pane, and DELETE it!


        }

        public void FindVRParts()
        {
            //Begin of find camera action
            function.DynaSceneNodeFind("Camera");
            dynamic responseCamera = client.SearchResponses(IDOperations.sceneNodeFind);
            Console.WriteLine("Camera info:");
            Console.WriteLine(responseCamera);
            //End of find camera action

            //Begin of find left hand action
            function.DynaSceneNodeFind("Left hand");
            dynamic responseLefthand = client.SearchResponses(IDOperations.sceneNodeFind);
            Console.WriteLine("Left hand info:");
            Console.WriteLine(responseLefthand);
            //End of find left hand action

            //Begin of find right hand action
            function.DynaSceneNodeFind("Right hand");
            dynamic responseRighthand = client.SearchResponses(IDOperations.sceneNodeFind);
            Console.WriteLine("Right hand info:");
            Console.WriteLine(responseRighthand);
            //End of find right hand action

            //Begin of find head action
            function.DynaSceneNodeFind("Head");
            dynamic responseHead = client.SearchResponses(IDOperations.sceneNodeFind);
            Console.WriteLine("Head info:");
            Console.WriteLine(responseHead);
            //End of find head action
        }

        public void FindEverything()
        {
            function.DynaSceneGet();
            dynamic getResponse = client.SearchResponses(IDOperations.sceneGet);
            Console.WriteLine(getResponse);
        }

        //Test methods from here, can ignore: 

        public void CreateFlatTerrain(int length, int width, int height)
        {
            function.DynaSceneTerrainAdd(new VRPoint2D(length, width), height);
        }

        public void DoRaycast()
        {
            function.DynaSceneRaycast(new VRPoint3D(0, 0, 0), new VRPoint3D(0, 1, 0), false);
            //JArray collision = response.response.data.data.data;
            //Console.WriteLine(collision.Count());
        }

        public void DoRaycast1()
        {
            function.DynaSceneRaycast(new int[] { 0, 0, 0 }, new int[] { 0, 1, 0 }, true);
            //JArray collision = response.response.data.data.data;
            //Console.WriteLine(collision.Count());
        }
    }


}
