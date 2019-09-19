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

        public VRResponse DynaGet(Sprint2VR.VR.Type type, Button button, Hand hand)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.type = type;
            if (type == Sprint2VR.VR.Type.button)
            {
                dynamicRequest.button = button;
                dynamicRequest.hand = hand;
            }
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.get, dynamicRequest));
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

        public VRResponse DynaSceneNodeAdd(string name, string parent, VRTransform vRTransform, VRModel vRModel, VRTerrain vRTerrain, VRPanel vRPanel, VRWater vRWater)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.name = name;
            //Optional fields - Begin
            if (parent != null)
                dynamicRequest.parent = parent;
            dynamic jObject = new JObject();
            if (vRTransform != null)
                jObject.Add("model", JObject.FromObject(vRTransform.GetDynamic().transform));
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
            dynamic dynamicRequest = new {id};
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneNodeDelete, dynamicRequest));
        }

        public VRResponse DynaSceneNodeFind(string name)
        {
            dynamic dynamicRequest = new { name };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneNodeFind, dynamicRequest));
        }

        public VRResponse DynaSceneNodeAddLayer(string id, string diffuse, string normal, double minHeight, double maxHeight, double fadeDist)
        {
            dynamic dynamicRequest = new
            {
                id,
                diffuse,
                normal,
                minHeight,
                maxHeight,
                fadeDist
            };
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneNodeAddlayer, dynamicRequest));
        }

        public VRResponse DynaSceneNodeDelLayer()
        {
            dynamic dynamicRequest = new{ };
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
            if (vRLines!=null)
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

    }
}
