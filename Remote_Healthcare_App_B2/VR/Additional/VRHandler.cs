﻿using ErgoConnect;
using Sprint2VR;
using Sprint2VR.VR;
using Sprint2VR.VR.Components;
using System;
using System.Collections.Generic;
using VRCode;
using VREngine.Additional;
using VREngine.Routes;

namespace VREngine
{
	public class VRHandler
	{
		private readonly VRClient client;
		private readonly Function function;
		private readonly VRData vRData;
		private readonly RouteHandler routeHandler;
		private readonly Program program;
		private int oldResistance = 0;
		private double speedBike = 0;
		private string doctorMessage = "";


		public VRHandler(Program program)
		{
			this.vRData = new VRData();
			this.client = new VRClient();
			this.routeHandler = new RouteHandler(this);
			this.program = program;

			this.client.Connect("145.48.6.10", 6666);
			System.Threading.Thread.Sleep(500);
			this.client.OpenTunnel("muffins");

			this.function = new Function(this.client);
			this.Init();
		}

		//static void Main(string[] args)
		//{
		//    new VRHandler();
		//    Console.Read();
		//}

		private void Init()
		{
			this.function.DynaSceneReset();
			this.CreateEnvironment();

			//Retrieving info.
			this.FindVRParts();
			this.FindEverything();
			//End of retrieving info.

			//Setting up parent and startposition.
			this.MoveVRParts(new VRPoint3D(0.9, -0.2, -0.44), new VRPoint3D(0, 90, 0), 1);
			this.MoveCar(new VRPoint3D(-19.30, 22.00, -13.40), new VRPoint3D(0, 0, 0), 1);
			this.MakeErgoParent();



			//Add panel and make vehicle parent.
			string panelUuid = this.AddPanel();
			this.vRData.uuidPanel = panelUuid;
			this.PanelAddParent(panelUuid, this.vRData.uuidVehicle);
			//PutTextOnPanel("Speed");
			//  SwapPanel(panelUuid);

			//Setting the route.
			string ID;
			ID = this.AddRouteFunction(this.routeHandler.GetRouteStart());
			this.SetRoute(ID);
			System.Threading.Thread.Sleep(1000);
			this.HideRoute();

			//if (true) // Enable for testing purposes.
			//    while (true)
			//        Console.WriteLine(GetResistanceChange());
			//FindAllParts();


			while (true)
			{
				int resistanceChange = this.GetResistanceChange(); // if -1 upwards, if 1 downwards.
				if (resistanceChange == 0)
				{
					if (this.oldResistance != 0)
					{
						this.program.ergo.SetResistance(50);
					}
				}

				if (resistanceChange == 1)
				{
					if (this.oldResistance != 1)
					{
						this.program.ergo.SetResistance(0);
					}
				}

				if (resistanceChange == -1)
				{
					if (this.oldResistance != -1)
					{
						this.program.ergo.SetResistance(100);
					}
				}

				if (this.program.ergo.emergencyBrake)
				{
					this.RefreshAndDraw("Stop!", "Stop!", "STOP");
					this.EmergencyStop();
				}
				BLEDataHandler handler = this.program.ergo.dataHandler;
				if (this.program.ergo.usingSim)
				{
					handler = this.program.bLESimulator.bLEDataHandler;
				}

				BLEDataPage16 data = handler.GetDataForVR();
				if (data != null)
				{
					this.doctorMessage = this.program.ergo.doctorMessage;
					this.RefreshAndDraw(data.speed.ToString(), data.heartRate.ToString(), this.doctorMessage);
					this.speedBike = (int)data.speed / 2.0;
					this.UpdateSpeedBike((int)(data.speed / 3.0));
					// UpdateSpeedBike(10);
				}
				else
				{
					//this.doctorMessage = "a message";
					//this.speedBike = 10;
					//RefreshAndDraw(this.speedBike.ToString(), "Nope", doctorMessage);
					//UpdateSpeedBike(this.speedBike);
				}
				this.oldResistance = this.GetResistanceChange();
				System.Threading.Thread.Sleep(75);
			}
		}

		public void EmergencyStop()
		{
			this.doctorMessage = "STOP";
			this.function.DynaPause();
		}

		//Organized code start:
		//Code to create the environment:
		public void CreateEnvironment()
		{
			//Begin of terrain heightmap + texture.
			bool doHeightmap = false;
			if (doHeightmap)
			{
				string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/heightmap.png";
				this.function.DynaSceneTerrainAdd(path);
				this.function.DynaSceneNodeAdd("terrain", null, new VRTransform(new VRPoint3D(-100, 0, -100), new VRPoint3D(0, 0, 0), 0.5), null, new VRTerrain(true), null, null);
				dynamic responseTerrainNode = this.client.SearchResponses(IDOperations.sceneNodeAdd);
				Console.WriteLine(responseTerrainNode);
				string terrainUuid = responseTerrainNode.data.data.data.uuid;
				this.function.DynaSceneNodeAddLayer(terrainUuid, @"data\NetworkEngine\textures\grass\grass.png", @"data\NetworkEngine\textures\grass\grass.png", 0, 10, 10);
			}
			//End of terrain heightmap + texture.

			//Begin of create water.
			this.function.DynaSceneNodeAdd("water", null, new VRTransform(new VRPoint3D(0, 13, 0), new VRPoint3D(0, 0, 0), 1), null, null, null, new VRWater(new VRPoint2D(1000, 1000), 5));
			dynamic responseWaterNode = this.client.SearchResponses(IDOperations.sceneNodeAdd);
			string waterUuid = responseWaterNode.data.data.data.uuid;
			Console.WriteLine(responseWaterNode);
			//End of create water.

			//Begin of create city.
			this.function.DynaSceneNodeAdd("city", null, new VRTransform(new VRPoint3D(0, 6, 0), new VRPoint3D(0, 0, 0), 1), new VRModel(@"data\NetworkEngine\models\houses\set1\citytest1.obj", false, false, null), null, null, null);
			dynamic responseCityNode = this.client.SearchResponses(IDOperations.sceneNodeAdd);
			string cityUuid = responseCityNode.data.data.data.uuid;
			Console.WriteLine(responseCityNode);
			//End of create city.

			//Begin of create skybox.
			string skyboxFolder = "spires";
			string skyboxName = "spires";
			string skyboxExtension = "png";
			VRSkybox vRSkybox = new VRSkybox();
			vRSkybox.SetCustomSkybox($"data/NetworkEngine/textures/SkyBoxes/{skyboxFolder}/{skyboxName}_rt.{skyboxExtension}", $"data/NetworkEngine/textures/SkyBoxes/{skyboxFolder}/{skyboxName}_lf.{skyboxExtension}", $"data/NetworkEngine/textures/SkyBoxes/{skyboxFolder}/{skyboxName}_up.{skyboxExtension}", $"data/NetworkEngine/textures/SkyBoxes/{skyboxFolder}/{skyboxName}_dn.{skyboxExtension}", $"data/NetworkEngine/textures/SkyBoxes/{skyboxFolder}/{skyboxName}_bk.{skyboxExtension}", $"data/NetworkEngine/textures/SkyBoxes/{skyboxFolder}/{skyboxName}_ft.{skyboxExtension}");
			this.function.DynaSceneSkyboxUpdate(vRSkybox);
			//End of create skybox.

			//Begin of create cart.
			this.function.DynaSceneNodeAdd("wooden_bicycle", null, new VRTransform(new VRPoint3D(0, 6, 0), new VRPoint3D(0, 0, 0), 1), new VRModel(@"data\NetworkEngine\models\misc\wooden_bicycle\wooden_bicycle.obj", false, false, null), null, null, null);
			dynamic responseVehicleNode = this.client.SearchResponses(IDOperations.sceneNodeAdd);
			string vehicleUuid = responseVehicleNode.data.data.data.uuid;
			Console.WriteLine(responseVehicleNode);
			this.vRData.uuidVehicle = vehicleUuid;
			//End of create cart.

			//Find standard pane, and DELETE it!
			this.function.DynaSceneNodeFind("GroundPlane");
			dynamic responseGroundplane = this.client.SearchResponses(IDOperations.sceneNodeFind);
			string uuid = responseGroundplane.data.data.uuid;
			Console.WriteLine("Groundplane info:");
			Console.WriteLine(responseGroundplane);
			//--> Delete it
			this.function.DynaSceneNodeDelete(uuid);
			//End of find standard pane, and DELETE it!
		}

		public void FindVRParts()
		{
			//Begin of find camera action.
			this.function.DynaSceneNodeFind("Camera");
			dynamic responseCamera = this.client.SearchResponses(IDOperations.sceneNodeFind);
			Console.WriteLine("Camera info:");
			Console.WriteLine(responseCamera);

			//Saving the uuid of the camera node.
			dynamic uuidCamera = responseCamera.data.data.data[0].uuid;
			this.vRData.uuidCamera = uuidCamera;
			//End of find camera action.

			//Begin of find left hand action.
			this.function.DynaSceneNodeFind("Left hand");
			dynamic responseLefthand = this.client.SearchResponses(IDOperations.sceneNodeFind);
			Console.WriteLine("Left hand info:");
			Console.WriteLine(responseLefthand);

			//Saving the uuid of the left hand node.
			dynamic uuidLeftHand = responseCamera.data.data.data[0].uuid;
			this.vRData.uuidLeftHand = uuidLeftHand;
			//End of saving the uuid of the left hand node.
			//End of find left hand action.

			//Begin of find right hand action.
			this.function.DynaSceneNodeFind("Right hand");
			dynamic responseRighthand = this.client.SearchResponses(IDOperations.sceneNodeFind);
			Console.WriteLine("Right hand info:");
			Console.WriteLine(responseRighthand);
			//Saving the uuid of the right hand node.
			dynamic uuidRightHand = responseCamera.data.data.data[0].uuid;
			this.vRData.uuidRightHand = uuidRightHand;
			//End of saving the uuid of the right hand node.
			//End of find right hand action.

			//Begin of find head action
			this.function.DynaSceneNodeFind("Head");
			dynamic responseHead = this.client.SearchResponses(IDOperations.sceneNodeFind);
			Console.WriteLine("Head info:");
			Console.WriteLine(responseHead);

			//Saving the uuid of the right hand node.
			dynamic uuidHead = responseCamera.data.data.data[0].uuid;
			this.vRData.uuidHead = uuidHead;
			//End of saving the uuid of the right hand node.
			//End of find head action.
		}

		public int GetResistanceChange()
		{
			double value = this.GetCarTransform();
			if (value > 0)
			{
				return 1;
			}

			if (value < 0)
			{
				return -1;
			}
			else
			{
				return 0;
			}
			// 1 = max resistance.
			// -1 = min resistance.
			// 0 normal resistance.
		}

		public void UpdateSpeedBike(double speed)
		{
			this.function.DynaRouteFollowSpeed(this.vRData.uuidVehicle, speed);
		}

		public string AddPanel()
		{
			this.function.DynaSceneNodeAdd("dashboardPanel", null, new VRTransform(new VRPoint3D(0.4, 1.1, -0.435), new VRPoint3D(0, 90, 0), 1), null, null, new VRPanel(new VRPoint2D(0.3, 0.05), new VRPoint2D(150, 400), new VRColor(0.0f, 0.0f, 0.0f, 1f), true), null);
			dynamic responsePanel = this.client.SearchResponses(IDOperations.sceneNodeAdd);
			string panelUuid = responsePanel.data.data.data.uuid;
			return panelUuid;
		}

		public void RefreshAndDraw(string speed, string heartrate, string doctorsmessage)
		{
			this.ClearPanel(this.vRData.uuidPanel);
			this.DisplayInformation(speed, heartrate, doctorsmessage);
			this.SwapPanel(this.vRData.uuidPanel);
		}

		public void PutTextOnPanel(string panelText, bool displayLow = false)
		{
			if (!displayLow)
			{
				this.function.DynaScenePanelDrawText(this.vRData.uuidPanel, panelText, new VRPoint2D(0, 25), 20, new VRColor(1f, 1f, 1f, 1f), "segoeui");
			}
			else
			{
				this.function.DynaScenePanelDrawText(this.vRData.uuidPanel, panelText, new VRPoint2D(0, 125), 20, new VRColor(1f, 1f, 1f, 1f), "segoeui");
			}
		}

		public void DisplayInformation(string speed, string heartrate, string doctorsmessage)
		{
			this.PutTextOnPanel($"Speed: {speed} HR: {heartrate}");
			this.PutTextOnPanel(doctorsmessage, true);
		}

		public void SwapPanel(string uuid)
		{
			this.function.DynaScenePanelSwap(uuid);
		}

		public void ClearPanel(string uuid)
		{
			this.function.DynaScenePanelClear(uuid);
		}

		public void PanelAddParent(string panelUuid, string parentUuid)
		{
			this.function.DynaSceneNodeUpdate(panelUuid, parentUuid, null, null);
		}

		public void SetRoute(string routeID, VRPoint3D rotation = null)
		{
			rotation = new VRPoint3D(0, Math.PI * 1.5, 0); // was Math.PI/180*90 overal
			if (rotation == null)
			{
				this.function.DynaRouteFollow(routeID, this.vRData.uuidVehicle, 0, 0, "XYZ", 0, false, new VRPoint3D(0, 0, 0), new VRPoint3D(0, 0, 0));
			}
			else
			{
				this.function.DynaRouteFollow(routeID, this.vRData.uuidVehicle, 0, 0, "XYZ", 1.0, false, rotation, new VRPoint3D(0, 0, 0));
			}
		}

		public string AddRouteToCrossing()
		{
			this.function.DynaRouteAdd(this.routeHandler.GetRouteStart());
			//Receive route response from server.
			dynamic responseRoute = this.client.SearchResponses(IDOperations.routeAdd);
			Console.WriteLine(responseRoute);
			return responseRoute.data.data.data.uuid;
		}


		public string AddRouteFunction(List<Route> routeHandlerRoute)
		{
			this.function.DynaRouteAdd(routeHandlerRoute);
			dynamic responseRoute = this.client.SearchResponses(IDOperations.routeAdd);
			return responseRoute.data.data.data.uuid;
		}

		public void HideRoute()
		{
			this.function.DynaRouteShow(false);
		}

		public VRPoint3D GetCarCoords()
		{
			this.function.DynaSceneNodeFind("wooden_bicycle");
			dynamic responsePosition = this.client.SearchResponses(IDOperations.sceneNodeFind);
			dynamic dataArray = responsePosition.data.data.data[0].components[0].position;
			//Console.WriteLine(dataArray);
			double xPos = (double)dataArray[0];
			double yPos = (double)dataArray[1];
			double zPos = (double)dataArray[2];
			return new VRPoint3D(xPos, yPos, zPos);
		}

		public double GetCarTransform()
		{
			this.function.DynaSceneNodeFind("wooden_bicycle");
			dynamic responseTransform = this.client.SearchResponses(IDOperations.sceneNodeFind);
			dynamic dataArray = responseTransform.data.data.data[0].components[0].rotation;
			return dataArray[2];
		}

		public void MoveVRParts(VRPoint3D posXYZ, VRPoint3D rotXYZ, double scale)
		{
			//Begin of moving the camera to a specific position.
			VRTransform vRTransform = new VRTransform(posXYZ, rotXYZ, scale);
			string id = this.vRData.uuidCamera;
			string parent = null;
			this.function.DynaSceneNodeUpdate(id, parent, vRTransform, null);
			//End of moving the camera to a specific position.
		}

		public void MoveCar(VRPoint3D posXYZ, VRPoint3D rotXYZ, double scale)
		{
			//Begin of moving the car to a specific position.
			VRTransform vRTransform = new VRTransform(posXYZ, rotXYZ, scale);
			string id = this.vRData.uuidVehicle;
			string parent = null;
			this.function.DynaSceneNodeUpdate(id, parent, vRTransform, null);
			//End of moving the car to a specific position.
		}

		public void MakeErgoParent()
		{
			//Begin of making ergometer parent of camera.
			string id = this.vRData.uuidCamera;
			string parent = this.vRData.uuidVehicle;
			this.function.DynaSceneNodeUpdate(id, parent, null, null);
			//End of making ergometer parent of camera.
		}

		public void FindEverything()
		{
			//Begin of searching all nodes, and printing them.
			this.function.DynaSceneGet();
			dynamic getResponse = this.client.SearchResponses(IDOperations.sceneGet);
			Console.WriteLine(getResponse);
			//End of searching all nodes, and printing them.
		}
	}
}
