using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sprint2VR.VR.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR
{
    public class IDOperations
    {
        //Network ID's
        public static string sessionList = "session/list";
        public static string tunnelCreate = "tunnel/create";
        public static string tunnelSend = "tunnel/send";

        //Pre ID's
        public static string get = "get";
        public static string setCallback = "setcallback";
        public static string play = "play";
        public static string pause = "pause";

        //Begin of scene block.
        //Scene pre ID's
        public static string sceneGet = "scene/get";
        public static string sceneReset = "scene/reset";
        public static string sceneSave = "scene/save";
        public static string sceneLoad = "scene/load";
        public static string sceneRaycast = "scene/raycast";
        //Scene-Node pre ID's
        public static string sceneNodeAdd = "scene/node/add";
        public static string sceneNodeUpdate = "scene/node/update";
        public static string sceneNodeMoveto = "scene/node/moveto";
        public static string sceneNodeDelete = "scene/node/delete";
        public static string sceneNodeFind = "scene/node/find";
        public static string sceneNodeAddlayer = "scene/node/addlayer";
        public static string sceneNodeDellayer = "scene/node/dellayer";
        //Scene-Panel pre ID's
        public static string scenePanelClear = "scene/panel/clear";
        public static string scenePanelSwap = "scene/panel/swap";
        public static string scenePanelDrawlines = "scene/panel/drawlines";
        public static string scenePanelSetclearcolor = "scene/panel/setclearcolor";
        public static string scenePanelDrawtext = "scene/panel/drawtext";
        public static string scenePanelImage = "scene/panel/image";
        //Scene-Terrain pre ID's
        public static string sceneTerrainAdd = "scene/terrain/add";
        public static string sceneTerrainUpdate = "scene/terrain/update";
        public static string sceneTerrainDelete = "scene/terrain/delete";
        public static string sceneTerrainGetheight = "scene/terrain/getheight";
        //Scene-Skybox pre ID's
        public static string sceneSkyboxSettime = "scene/skybox/settime";
        public static string sceneSkyboxUpdate = "scene/skybox/update";
        //Scene-Road pre ID's 
        public static string sceneRoadAdd = "scene/road/add";
        public static string sceneRoadUpdate = "scene/road/update";
        //End of scene block.

        //Begin of route block.
        //Route pre ID's
        public static string routeAdd = "route/add";
        public static string routeUpdate = "route/update";
        public static string routeDelete = "route/delete";
        public static string routeFollow = "route/follow";
        public static string routeShow = "route/show";
        //Route-Follow pre ID's
        public static string routeFollowSpeed = "route/follow/speed";
        //End of route block.

        //Extra ID's
        public static string empty = "";

    }

    public enum Type
    {
        head, handleft, handright, button
    }

    public enum Button
    {
        trigger, thumbpad, application, grip, notApplicable
    }

    public enum Hand
    {
        left, right, notApplicable
    }

    public class VRHelper
    {
        public Client _client;
        public string _tunnelID;

        private VRConnectionHandler _vRConnectionHandler;

        public VRHelper()
        {
            _vRConnectionHandler = new VRConnectionHandler("145.48.6.10", 6666);
            _client = _vRConnectionHandler._client;
            _tunnelID = GetTunnelID(GetSessionID(), "");
        }

        public void init()
        {

        }

        public dynamic GetRequestDynamic(dynamic request)
        {
            var dynamicRequest = new
            {
                id = IDOperations.tunnelSend,
                data = new
                {
                    dest = this._tunnelID,
                    data = request
                }
            };
            return dynamicRequest;
        }

        public dynamic AddData(string idOperation, dynamic request)
        {
            var dynamicRequest = new
            {
                id = idOperation,
                data = request
                };
            return dynamicRequest;
        }

        public dynamic GetFullRequest(string idOperation, dynamic request)
        {
            return GetRequestDynamic(AddData(idOperation, request));
        }

        public static dynamic GetIDData(string idOperation, dynamic request)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.id = idOperation;
            if (request != null)
                dynamicRequest.data = request;
            return dynamicRequest;
        }

        private dynamic GetTunnelID(string sessionID, string key)
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.session = sessionID;
            dynamicRequest.key = key;
            dynamicRequest = GetIDData(IDOperations.tunnelCreate, dynamicRequest);
            VRResponse vRResponse = DoSimpleRequest(dynamicRequest);
            return vRResponse.response.data.id;
        }

        private string GetSessionID()
        {
            VRResponse vRResponse = DoSimpleRequest(GetSimpleRequest(IDOperations.sessionList));
            string sessionID = String.Empty;
            foreach (var session in vRResponse.response.data)
                if (session.clientinfo.user == Environment.UserName) 
                    sessionID = session.id;
            return sessionID;
        }


        public static dynamic GetSimpleRequest(string idOperation)
        {
            dynamic request = new JObject();
            request.id = idOperation;
            return request;
        }

     
        private VRResponse DoSimpleRequest(dynamic request)
        {
            _client.WriteMessage(request);
            dynamic response = _client.ReadMessage();
            VRResponse vRResponse = new VRResponse(request, response);
            return vRResponse;
        }

        public VRResponse DoVRRequest(dynamic request)
        {
            dynamic fullRequest = GetRequestDynamic(request);
            return DoSimpleRequest(request);
        }



    }
}
