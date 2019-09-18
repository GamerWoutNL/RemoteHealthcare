using Newtonsoft.Json.Linq;
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

            if (vRTransform != null)
                dynamicRequest.components.transform = vRTransform.GetDynamic().transform;
            if (vRModel != null)
                dynamicRequest.components.model = vRModel.GetDynamic().model;
            if (vRTerrain != null)
                dynamicRequest.components.terrain = vRTerrain.GetDynamic().terrain;
            if (vRPanel != null)
                dynamicRequest.components.panel = vRPanel.GetDynamic().panel;
            if (vRWater != null)
                dynamicRequest.components.water = vRWater.GetDynamic().water;

            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneNodeAdd, dynamicRequest));
        }

        public VRResponse DynaSceneTerrainAdd(VRPoint2D size, int[] heightmap)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.size = size.GetDynamic().position;
            dynamicRequest.heights = new JArray(heightmap);
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneTerrainAdd, dynamicRequest));
        }

    }
}
