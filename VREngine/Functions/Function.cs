using Newtonsoft.Json.Linq;
using Sprint2VR;
using Sprint2VR.VR;
using Sprint2VR.VR.Additional;
using Sprint2VR.VR.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCode
{

    class Function
    {
        private Client _client;
        private string _tunnelID;
        private VRHelper _vRHelper;

        public Function(Client client, string tunnelID, VRHelper vRHelper)
        {
            this._client = client;
            this._tunnelID = tunnelID;
            this._vRHelper = vRHelper;
        }

        public void DynaGet(Sprint2VR.VR.Type type, Button button, Hand hand)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.type = type;
			if (type == Sprint2VR.VR.Type.button)
			{
				dynamicRequest.button = button;
				dynamicRequest.hand = hand;
			};
			_vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.get, dynamicRequest));
		}

        public VRResponse DynaSetCallback(Sprint2VR.VR.Type type, Button button, Hand hand)
        {
            dynamic dynamicRequest = new
            {
                type,
                button,
                hand
            };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.setCallback, dynamicRequest));
        }

        public VRResponse DynaPlay()
        {
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.play, new { }));
        }

        public VRResponse DynaPause()
        {
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.pause, new { }));
        }

        public VRResponse DynaSceneGet()
        {
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneGet, new { }));
        }

        public VRResponse DynaSceneReset()
        {
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneReset, new { }));
        }

        public VRResponse DynaSceneSave(string filename, bool overwrite)
        {
            dynamic dynamicRequest = new
            {
                filename,
                overwrite
            };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneSave, dynamicRequest));
        }

        public VRResponse DynaSceneLoad(string filename)
        {
            dynamic dynamicRequest = new
            {
                filename
            };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneLoad, dynamicRequest()));
        }

        public VRResponse DynaSceneRaycast(VRPoint3D start, VRPoint3D direction, bool physics)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.start = JArray.FromObject(start.GetDynamic().position);
            dynamicRequest.direction = JArray.FromObject(direction.GetDynamic().position);
            dynamicRequest.physics = physics;
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneRaycast, dynamicRequest));
        }

        public VRResponse DynaSceneRaycast(int[] start, int[] direction, bool physics)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.start = JArray.FromObject(start);
            dynamicRequest.direction = JArray.FromObject(direction);
            dynamicRequest.physics = physics;
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneRaycast, dynamicRequest));
        }

        public VRResponse DynaSceneNodeAdd(string name, string parent, VRTransform vRTransform, VRModel vRModel, VRTerrain vRTerrain, VRPanel vRPanel, VRWater vRWater)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.name = name;
            //Optional fields - Begin
            if (parent != null)
                dynamicRequest.parent = parent;
            dynamic jObject = new JObject();
			if (vRTransform != null)
                jObject.transform = JObject.FromObject(vRTransform.GetDynamic().transform);
            if (vRModel != null)
                jObject.model = JObject.FromObject(vRModel.GetDynamic().model);
            if (vRTerrain != null)
                jObject.terrain = JObject.FromObject(vRTerrain.GetDynamic().terrain);
            if (vRPanel != null)
                jObject.panel = JObject.FromObject(vRPanel.GetDynamic().panel);
            if (vRWater != null)
                jObject.water = JObject.FromObject(vRWater.GetDynamic().water);
            //Optional fields - End
            if (vRTransform == null || vRModel == null || vRTerrain == null || vRPanel == null || vRWater == null)
                dynamicRequest.Add("components", jObject);
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneNodeAdd, dynamicRequest));
        }

        public VRResponse DynaSceneNodeUpdate(string id, string parent, VRTransform vRTransform, VRAnimation vRAnimation)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.id = new { id };
            if (parent != null)
                dynamicRequest.parent = new { parent };
            if (vRTransform != null)
                dynamicRequest.transform = JObject.FromObject(vRTransform.GetDynamic().transform);
            if (vRAnimation != null)
                dynamicRequest.animation = JObject.FromObject(vRTransform.GetDynamic().animation);
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneNodeUpdate, dynamicRequest));
        }

        public VRResponse DynaSceneNodeMoveTo(string id, string stop, VRPoint3D position, VRPoint2D rotation, string interpolate, bool followHeight, double timeOrSpeed, bool isTime)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.id = new { id };
            dynamicRequest.stop = stop;
            dynamicRequest.position = JObject.FromObject(position.GetDynamic().position);
            dynamicRequest.rotate = JObject.FromObject(position.GetDynamic().position);
            dynamicRequest.interpolate = interpolate;
            dynamicRequest.followheight = followHeight;
            if (isTime)
                dynamicRequest.time = timeOrSpeed;
            else dynamicRequest.speed = timeOrSpeed;
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneNodeMoveto, dynamicRequest));
        }

        public VRResponse DynaSceneNodeDelete(string id)
        {
            dynamic dynamicRequest = new { id };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneNodeDelete, dynamicRequest));
        }

        public VRResponse DynaSceneNodeFind(string name)
        {
            dynamic dynamicRequest = new { name };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneNodeFind, dynamicRequest));
        }

        public VRResponse DynaSceneNodeAddLayer(string id, string diffuse, string normal, double minHeight, double maxHeight, double fadeDist)
        {
            //dynamic dynamicRequest = new
            //{
            //    id=new JObject(id),
            //    diffuse=new JObject(diffuse),
            //    normal=new JObject(normal),
            //    minHeight,
            //    maxHeight,
            //    fadeDist
            //};

            dynamic dynamicRequest = new JObject();
            dynamicRequest.id = id;
            dynamicRequest.diffuse = diffuse;
            dynamicRequest.normal = normal;
            dynamicRequest.minHeight = minHeight;
            dynamicRequest.maxHeight = maxHeight;
            dynamicRequest.fadeDist = fadeDist;
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneNodeAddlayer, dynamicRequest));
        }

        public VRResponse DynaSceneNodeDelLayer()
        {
            dynamic dynamicRequest = new { };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneNodeDellayer, dynamicRequest));
        }

        public VRResponse DynaScenePanelClear(string id)
        {
            dynamic dynamicRequest = new { id };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.scenePanelClear, dynamicRequest));
        }

        public VRResponse DynaScenePanelSwap(string id)
        {
            dynamic dynamicRequest = new { id };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.scenePanelSwap, dynamicRequest));
        }

        public VRResponse DynaScenePanelDrawLines(string id, double width, params VRLine[] vRLines)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.id = id;
            dynamicRequest.width = width;
            JArray jArray = new JArray();
            if (vRLines != null)
            {
                for (int i = 0; i < vRLines.Length; i++)
                    jArray.Add(JObject.FromObject(vRLines[i].GetDynamic().line));
                dynamicRequest.lines = jArray;
            }
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.scenePanelDrawlines, dynamicRequest));
        }

        public VRResponse DynaScenePanelSetClearColor(string id, VRColor color)
        {
            dynamic dynamicRequest = new
            {
                id = new { id },
                color = JObject.FromObject(color.GetDynamic().color)
            };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.scenePanelSetclearcolor, dynamicRequest));
        }

        public VRResponse DynaScenePanelDrawText(string id, string text, VRPoint2D position, double size, VRColor color, string font)
        {
            dynamic dynamicRequest = new
            {
                id,
                text,
                position = JObject.FromObject(position.GetDynamic().position),
                size,
                color = JObject.FromObject(position.GetDynamic().color),
                font
            };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.scenePanelDrawtext, dynamicRequest));
        }

        public VRResponse DynaScenePanelImage(string id, string image, VRPoint2D position, VRPoint2D size)
        {
            dynamic dynamicRequest = new
            {
                id = new { id },
                image,
                position = JObject.FromObject(position.GetDynamic().position),
                size = JObject.FromObject(size.GetDynamic().position)
            };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.scenePanelImage, dynamicRequest));
        }

        public VRResponse DynaSceneTerrainAdd(string file)
        {
            dynamic dynamicRequest = new JObject();
            using (Bitmap heightmap = new Bitmap(file))
            {
                float[,] heights = new float[heightmap.Width, heightmap.Height];

                for (int x = 0; x < heightmap.Width; x++)
                {
                    for (int y = 0; y < heightmap.Height; y++)
                    {
                        heights[x, y] = (heightmap.GetPixel(x, y).R / 256.0f) * 25.0f;
                    }
                }
                dynamicRequest.size = JArray.FromObject(new[] { heightmap.Width, heightmap.Height });
                dynamicRequest.heights = JArray.FromObject(heights.Cast<float>().ToArray());
            }

            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneTerrainAdd, dynamicRequest));
        }

        public VRResponse DynaSceneTerrainAdd(VRPoint2D size, float height)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.size = JArray.FromObject(size.GetDynamic().position);
            JArray heights = new JArray();
            for (int i = 0; i < size.posx * size.posy; i++)
                heights.Add(height);
            dynamicRequest.heights = JArray.FromObject(heights);
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneTerrainAdd, dynamicRequest));
        }

        public VRResponse DynaSceneTerrainUpdate()
        {
            dynamic dynamicRequest = new { };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneTerrainUpdate, dynamicRequest));
        }

        public VRResponse DynaSceneTerrainDelete()
        {
            dynamic dynamicRequest = new { };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneTerrainDelete, dynamicRequest));
        }

        public VRResponse DynaSceneTerrainGetHeight(params VRPoint2D[] positions)
        {
            dynamic dynamicRequest = new JObject();
            JArray jArray = new JArray();
            foreach (VRPoint2D position in positions)
                jArray.Add(JArray.FromObject(position.GetDynamic().position));
            dynamicRequest.positions = jArray;
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneTerrainGetheight, dynamicRequest));
        }

        public VRResponse DynaSceneSkyboxSettime(float time)
        {
            dynamic dynamicRequest = new
            {
                time
            };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneSkyboxSettime, dynamicRequest));
        }

        public VRResponse DynaSceneSkyboxUpdate(VRSkybox vRSkybox)
        {
            dynamic dynamicRequest = vRSkybox.GetDynamic();
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneSkyboxUpdate, dynamicRequest));
        }

		public VRResponse DynaRouteAdd(VRPoint3D[] positions, VRPoint3D[] directions)
        {
            dynamic dynamicRequest = new JObject();
            JArray jArraypos = new JArray();
            JArray jArraydir = new JArray();
            foreach (VRPoint3D position in positions)
                jArraypos.Add(JObject.FromObject(position.GetDynamic().pos));
            foreach (VRPoint3D direction in directions)
                jArraydir.Add (JObject.FromObject(direction.GetDynamic().dir));
            dynamicRequest.positions = jArraypos;
            dynamicRequest.directions = jArraydir;
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.routeAdd, dynamicRequest));
        }
        public VRResponse DynaRouteUpdate(VRPoint3D vRPoint3D)
        {
            dynamic dynamicRequest = vRPoint3D.GetDynamic();
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.routeUpdate, dynamicRequest));
        }
        public VRResponse DynaRouteDelete()
        {
            dynamic dynamicRequest = new {};
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.routeDelete, dynamicRequest));
        }
        public VRResponse DynaRouteFollow(string routeID, string nodeID, double speed, double offset, string rotate, double smoothing, bool followHeight, VRPoint3D rotateOffset, VRPoint3D posOffset)
        {
            dynamic dynamicRequest = new JObject();
			dynamicRequest.route = new { routeID };
			dynamicRequest.node = new { nodeID };
			dynamicRequest.speed = speed;
			dynamicRequest.offset = offset;
			dynamicRequest.rotate = rotate;
			dynamicRequest.smoothing = smoothing;
			dynamicRequest.followHeight = followHeight;
			dynamicRequest.rotateOffset = JArray.FromObject(rotateOffset.GetDynamic().position);
			dynamicRequest.positionOffset = JArray.FromObject(posOffset.GetDynamic().position);


            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.routeFollow, dynamicRequest));
        }
        public VRResponse DynaRouteFollowSpeed(string id, double speed)
        {
            dynamic dynamicRequest = new
            {
                id = new { id },
                speed
            };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.routeFollowSpeed, dynamicRequest));
        }
        public VRResponse DynaRouteShow(bool visibility)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.visibil = visibility;
            return dynamicRequest;
           
        }
        public VRResponse DynaRoadAdd(string id, double heightoffset)
        {
            dynamic dynamicRequest = new
            {
                id = new { id },
                heightoffset
            };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneRoadAdd, dynamicRequest));
        }

        public VRResponse DynaRoadUpdate()
        {
            dynamic dynamicRequest = new {};
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneRoadUpdate, dynamicRequest));
        }
    }
}
