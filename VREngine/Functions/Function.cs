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
            dynamicRequest.parent = parent;
            dynamicRequest.components = new { };

            if (vRTransform != null)
                dynamicRequest.transform = vRTransform.GetDynamic().transform;
            if (vRModel != null)
                dynamicRequest.model = vRModel.GetDynamic().model;
            if (vRTerrain != null)
                dynamicRequest.terrain = vRTerrain.GetDynamic().terrain;
            if (vRPanel != null)
                dynamicRequest.panel = vRPanel.GetDynamic().panel;
            if (vRWater != null)
                dynamicRequest.water = vRWater.GetDynamic().water;

            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneNodeAdd, dynamicRequest));
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
