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

         

        public VRResponse DynaSceneTerrainAdd(VRPoint2D size, int[] heightmap)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.size = size.GetDynamic().position;
            dynamicRequest.heights = new JArray(heightmap);
            return _vRHelper.DoVRRequest(_vRHelper.GetFullRequest(IDOperations.sceneTerrainAdd, dynamicRequest));
        }

    }
}
