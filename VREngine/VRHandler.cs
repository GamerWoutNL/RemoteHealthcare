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
		private string terrainUuid = "";

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
			CreateTerrain();
			CreateTerrainNode();
			AddTexture();
			CreateWaterNode();
			System.Threading.Thread.Sleep(2000);
			CreateCityNode();
			CreateSkybox("spires", "spires", "png");
		}

		public void CreateFlatTerrain(int length, int width, int height)
		{
			function.DynaSceneTerrainAdd(new VRPoint2D(length, width), height);
		}

		public void CreateTerrain()
		{
			string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/heightmap.png";
			function.DynaSceneTerrainAdd(path);
			//function.DynaSceneNodeAdd("terrain", "", null, null, new VRTerrain(true), null, null);

			JObject response = client.SearchResponses(IDOperations.sceneTerrainAdd);

			Console.WriteLine(response);
		}

		public void CreateTerrainNode()
		{
			function.DynaSceneNodeAdd("terrain", null, new VRTransform(new VRPoint3D(-100, 0, -100), new VRPoint3D(0, 0, 0), 0.5), null, new VRTerrain(true), null, null);
			JObject response = client.SearchResponses(IDOperations.sceneNodeAdd);

			Console.WriteLine(response);

			// TODO: Get the terrain uuid
			//this.terrainUuid = response.response.data.data.data.uuid;
		}

		public void CreateWaterNode()
		{
			function.DynaSceneNodeAdd("water", null, new VRTransform(new VRPoint3D(0, 13, 0), new VRPoint3D(0, 0, 0), 1), null, null, null, new VRWater(new VRPoint2D(1000, 1000), 5));
		}

		public void CreateCityNode()
		{
			function.DynaSceneNodeAdd("city", null, new VRTransform(new VRPoint3D(0, 6, 0), new VRPoint3D(0, 0, 0), 1), new VRModel(@"data\NetworkEngine\models\houses\set1\citytest1.obj", false, false, null), null, null, null);
		}

		public void CreateSkybox(string folder, string name, string extension)
		{
			VRSkybox vRSkybox = new VRSkybox();
			vRSkybox.SetCustomSkybox($"data/NetworkEngine/textures/SkyBoxes/{folder}/{name}_rt.{extension}", $"data/NetworkEngine/textures/SkyBoxes/{folder}/{name}_lf.{extension}", $"data/NetworkEngine/textures/SkyBoxes/{folder}/{name}_up.{extension}", $"data/NetworkEngine/textures/SkyBoxes/{folder}/{name}_dn.{extension}", $"data/NetworkEngine/textures/SkyBoxes/{folder}/{name}_bk.{extension}", $"data/NetworkEngine/textures/SkyBoxes/{folder}/{name}_ft.{extension}");
			function.DynaSceneSkyboxUpdate(vRSkybox);
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

		public void AddTexture()
		{
			function.DynaSceneNodeAddLayer(this.terrainUuid, @"data\NetworkEngine\textures\grass\grass.png", @"data\NetworkEngine\textures\grass\grass.png", 0, 10, 10);
		}
	}


}
