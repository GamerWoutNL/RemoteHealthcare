using Newtonsoft.Json.Linq;
using Sprint2VR;
using Sprint2VR.VR;
using Sprint2VR.VR.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VREngine.Routes;

namespace VRCode
{

    class Function
    {
        private Client _client;

        public Function(Client client)
        {
            this._client = client;
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

            this._client.SendTunnel(IDOperations.get, dynamicRequest);
        }

        public void DynaSetCallback(Sprint2VR.VR.Type type, Button button, Hand hand)
        {
            dynamic dynamicRequest = new
            {
                type,
                button,
                hand
            };
            this._client.SendTunnel(IDOperations.setCallback, dynamicRequest);
        }

        public void DynaPlay()
        {
            this._client.SendTunnel(IDOperations.play, new { });
        }

        public void DynaPause()
        {
            this._client.SendTunnel(IDOperations.pause, new { });
        }

        public void DynaSceneGet()
        {
            this._client.SendTunnel(IDOperations.sceneGet, new { });
        }

        public void DynaSceneReset()
        {
            this._client.SendTunnel(IDOperations.sceneReset, new { });
        }

        public void DynaSceneSave(string filename, bool overwrite)
        {
            dynamic dynamicRequest = new
            {
                filename,
                overwrite
            };
            this._client.SendTunnel(IDOperations.sceneSave, dynamicRequest);
        }

        public void DynaSceneLoad(string filename)
        {
            dynamic dynamicRequest = new
            {
                filename
            };
            this._client.SendTunnel(IDOperations.sceneLoad, dynamicRequest);
        }

        public void DynaSceneRaycast(VRPoint3D start, VRPoint3D direction, bool physics)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.start = JArray.FromObject(start.GetDynamic().position);
            dynamicRequest.direction = JArray.FromObject(direction.GetDynamic().position);
            dynamicRequest.physics = physics;
            this._client.SendTunnel(IDOperations.sceneRaycast, dynamicRequest);
        }

        public void DynaSceneRaycast(int[] start, int[] direction, bool physics)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.start = JArray.FromObject(start);
            dynamicRequest.direction = JArray.FromObject(direction);
            dynamicRequest.physics = physics;
            this._client.SendTunnel(IDOperations.sceneRaycast, dynamicRequest);
        }

        public void DynaSceneNodeAdd(string name, string parent, VRTransform vRTransform, VRModel vRModel, VRTerrain vRTerrain, VRPanel vRPanel, VRWater vRWater)
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
            this._client.SendTunnel(IDOperations.sceneNodeAdd, dynamicRequest);
        }

        public void DynaSceneNodeUpdate(string id, string parent, VRTransform vRTransform, VRAnimation vRAnimation)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.id = id;
            if (parent != null)
                dynamicRequest.parent = parent;
            if (vRTransform != null)
                dynamicRequest.transform = JObject.FromObject(vRTransform.GetDynamic().transform);
            if (vRAnimation != null)
                dynamicRequest.animation = JObject.FromObject(vRTransform.GetDynamic().animation);
            this._client.SendTunnel(IDOperations.sceneNodeUpdate, dynamicRequest);
        }

        public void DynaSceneNodeMoveTo(string id, string stop, VRPoint3D position, string rotate, string interpolate, bool followHeight, double timeOrSpeed, bool isTime)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.id = id;
            if (stop != null)
                dynamicRequest.stop = stop;
            dynamicRequest.position = JArray.FromObject(position.GetDynamic().position);
            dynamicRequest.rotate = rotate;
            dynamicRequest.interpolate = interpolate;
            dynamicRequest.followheight = followHeight;
            if (isTime)
                dynamicRequest.time = timeOrSpeed;
            else dynamicRequest.speed = timeOrSpeed;
            this._client.SendTunnel(IDOperations.sceneNodeMoveto, dynamicRequest);
        }

        public void DynaSceneNodeDelete(string id)
        {
            dynamic dynamicRequest = new { id }; // Might be dynamicRequest = id
            this._client.SendTunnel(IDOperations.sceneNodeDelete, dynamicRequest);
        }

        public void DynaSceneNodeFind(string name)
        {
            dynamic dynamicRequest = new { name }; // Might be dynamicRequest = id
            this._client.SendTunnel(IDOperations.sceneNodeFind, dynamicRequest);
        }

        public void DynaSceneNodeAddLayer(string id, string diffuse, string normal, double minHeight, double maxHeight, double fadeDist)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.id = id;
            dynamicRequest.diffuse = diffuse;
            dynamicRequest.normal = normal;
            dynamicRequest.minHeight = minHeight;
            dynamicRequest.maxHeight = maxHeight;
            dynamicRequest.fadeDist = fadeDist;
            this._client.SendTunnel(IDOperations.sceneNodeAddlayer, dynamicRequest);
        }

        public void DynaSceneNodeDelLayer()
        {
            dynamic dynamicRequest = new { };
            this._client.SendTunnel(IDOperations.sceneNodeDellayer, dynamicRequest);
        }

        public void DynaScenePanelClear(string id)
        {
            dynamic dynamicRequest = new { id }; // Might be dynamicRequest = id
            this._client.SendTunnel(IDOperations.scenePanelClear, dynamicRequest);
        }

        public void DynaScenePanelSwap(string id)
        {
            dynamic dynamicRequest = new { id }; // Might be dynamicRequest = id
            this._client.SendTunnel(IDOperations.scenePanelSwap, dynamicRequest);
        }

        public void DynaScenePanelDrawLines(string id, double width, params VRLine[] vRLines)
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

            this._client.SendTunnel(IDOperations.scenePanelDrawlines, dynamicRequest);
        }

        public void DynaScenePanelSetClearColor(string id, VRColor color)
        {
            dynamic dynamicRequest = new
            {
                id = new { id }, // Might be dynamicRequest = id
                color = JObject.FromObject(color.GetDynamic().color)
            };
            this._client.SendTunnel(IDOperations.scenePanelSetclearcolor, dynamicRequest);
        }

        public void DynaScenePanelDrawText(string id, string text, VRPoint2D position, double size, VRColor color, string font)
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
            this._client.SendTunnel(IDOperations.scenePanelDrawtext, dynamicRequest);
        }

        public void DynaScenePanelImage(string id, string image, VRPoint2D position, VRPoint2D size)
        {
            dynamic dynamicRequest = new
            {
                id = new { id }, // Might be dynamicRequest = id
                image,
                position = JObject.FromObject(position.GetDynamic().position),
                size = JObject.FromObject(size.GetDynamic().position)
            };
            this._client.SendTunnel(IDOperations.scenePanelImage, dynamicRequest);
        }

        public void DynaSceneTerrainAdd(string file)
        {
            dynamic dynamicRequest = new JObject();
            using (Bitmap heightmap = new Bitmap(file))
            {
                float[,] heights = new float[heightmap.Width, heightmap.Height];
                for (int x = 0; x < heightmap.Width; x++)
                    for (int y = 0; y < heightmap.Height; y++)
                        heights[x, y] = (heightmap.GetPixel(x, y).R / 256.0f) * 25.0f;
                dynamicRequest.size = JArray.FromObject(new[] { heightmap.Width, heightmap.Height });
                dynamicRequest.heights = JArray.FromObject(heights.Cast<float>().ToArray());
            }
            this._client.SendTunnel(IDOperations.sceneTerrainAdd, dynamicRequest);
        }

        public void DynaSceneTerrainAdd(VRPoint2D size, float height)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.size = JArray.FromObject(size.GetDynamic().position);
            JArray heights = new JArray();
            for (int i = 0; i < size.posx * size.posy; i++)
                heights.Add(height);
            dynamicRequest.heights = JArray.FromObject(heights);
            this._client.SendTunnel(IDOperations.sceneTerrainAdd, dynamicRequest);
        }

        public void DynaSceneTerrainUpdate()
        {
            dynamic dynamicRequest = new { };
            this._client.SendTunnel(IDOperations.sceneTerrainUpdate, dynamicRequest);
        }

        public void DynaSceneTerrainDelete()
        {
            dynamic dynamicRequest = new { };
            this._client.SendTunnel(IDOperations.sceneTerrainDelete, dynamicRequest);
        }

        public void DynaSceneTerrainGetHeight(params VRPoint2D[] positions)
        {
            dynamic dynamicRequest = new JObject();
            JArray jArray = new JArray();
            foreach (VRPoint2D position in positions)
                jArray.Add(JArray.FromObject(position.GetDynamic().position));
            dynamicRequest.positions = jArray;
            this._client.SendTunnel(IDOperations.sceneTerrainGetheight, dynamicRequest);
        }

        public void DynaSceneSkyboxSettime(float time)
        {
            dynamic dynamicRequest = new
            {
                time
            };
            this._client.SendTunnel(IDOperations.sceneSkyboxSettime, dynamicRequest);
        }

        public void DynaSceneSkyboxUpdate(VRSkybox vRSkybox)
        {
            dynamic dynamicRequest = vRSkybox.GetDynamic();
            this._client.SendTunnel(IDOperations.sceneSkyboxUpdate, dynamicRequest);
        }

        public void DynaRouteAdd(List<Route> routes)
        {
            dynamic dynamicRequest = new JObject();
            JArray list = new JArray();
            foreach (Route route in routes)
            {
                dynamic dataValue;
                dataValue = new
                {
                    pos = route.endPos.GetDynamic().position,
                    dir = route.rotation.GetDynamic().position
                };
                list.Add(JObject.FromObject(dataValue));
            }
            dynamicRequest.nodes = list;
            this._client.SendTunnel(IDOperations.routeAdd, dynamicRequest);
        }
        public void DynaRouteUpdate(VRPoint3D vRPoint3D)
        {
            dynamic dynamicRequest = vRPoint3D.GetDynamic();
            this._client.SendTunnel(IDOperations.routeUpdate, dynamicRequest);
        }
        public void DynaRouteDelete()
        {
            dynamic dynamicRequest = new { };
            this._client.SendTunnel(IDOperations.routeDelete, dynamicRequest);
        }
        public void DynaRouteFollow(string routeID, string nodeID, double speed, double offset, string rotate, double smoothing, bool followHeight, VRPoint3D rotateOffset, VRPoint3D posOffset)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.route = routeID;
            dynamicRequest.node = nodeID;
            dynamicRequest.speed = speed;
            dynamicRequest.offset = offset;
            dynamicRequest.rotate = rotate;
            dynamicRequest.smoothing = smoothing;
            dynamicRequest.followHeight = followHeight;
            dynamicRequest.rotateOffset = JArray.FromObject(rotateOffset.GetDynamic().position);
            dynamicRequest.positionOffset = JArray.FromObject(posOffset.GetDynamic().position);
            this._client.SendTunnel(IDOperations.routeFollow, dynamicRequest);
        }
        public void DynaRouteFollowSpeed(string id, double speed)
        {
            dynamic dynamicRequest = new
            {
                id = new { id }, // Might be id = id
                speed
            };
            this._client.SendTunnel(IDOperations.routeFollowSpeed, dynamicRequest);
        }
        public void DynaRouteShow(bool visibility)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.visibil = visibility;
            this._client.SendTunnel(IDOperations.routeShow, dynamicRequest);
        }
        public void DynaRoadAdd(string id, double heightoffset)
        {
            dynamic dynamicRequest = new
            {
                id = new { id }, // Might be id = id
                heightoffset
            };
            this._client.SendTunnel(IDOperations.sceneRoadAdd, dynamicRequest);
        }

        public void DynaRoadUpdate()
        {
            dynamic dynamicRequest = new { };
            this._client.SendTunnel(IDOperations.sceneRoadUpdate, dynamicRequest);
        }
    }
}
