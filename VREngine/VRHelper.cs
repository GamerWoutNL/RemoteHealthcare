using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sprint2VR.VR.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VREngine.Additional;

namespace Sprint2VR.VR
{
    public class IDOperations
    {
        //Network ID's
        public const string sessionList = "session/list";
        public const string tunnelCreate = "tunnel/create";
        public const string tunnelSend = "tunnel/send";

        //Pre ID's
        public const string get = "get";
        public const string setCallback = "setcallback";
        public const string play = "play";
        public const string pause = "pause";

        //Begin of scene block.
        //Scene pre ID's
        public const string sceneGet = "scene/get";
        public const string sceneReset = "scene/reset";
        public const string sceneSave = "scene/save";
        public const string sceneLoad = "scene/load";
        public const string sceneRaycast = "scene/raycast";
        //Scene-Node pre ID's
        public const string sceneNodeAdd = "scene/node/add";
        public const string sceneNodeUpdate = "scene/node/update";
        public const string sceneNodeMoveto = "scene/node/moveto";
        public const string sceneNodeDelete = "scene/node/delete";
        public const string sceneNodeFind = "scene/node/find";
        public const string sceneNodeAddlayer = "scene/node/addlayer";
        public const string sceneNodeDellayer = "scene/node/dellayer";
        //Scene-Panel pre ID's
        public const string scenePanelClear = "scene/panel/clear";
        public const string scenePanelSwap = "scene/panel/swap";
        public const string scenePanelDrawlines = "scene/panel/drawlines";
        public const string scenePanelSetclearcolor = "scene/panel/setclearcolor";
        public const string scenePanelDrawtext = "scene/panel/drawtext";
        public const string scenePanelImage = "scene/panel/image";
        //Scene-Terrain pre ID's
        public const string sceneTerrainAdd = "scene/terrain/add";
        public const string sceneTerrainUpdate = "scene/terrain/update";
        public const string sceneTerrainDelete = "scene/terrain/delete";
        public const string sceneTerrainGetheight = "scene/terrain/getheight";
        //Scene-Skybox pre ID's
        public const string sceneSkyboxSettime = "scene/skybox/settime";
        public const string sceneSkyboxUpdate = "scene/skybox/update";
        //Scene-Road pre ID's 
        public const string sceneRoadAdd = "scene/road/add";
        public const string sceneRoadUpdate = "scene/road/update";
        //End of scene block.

        //Begin of route block.
        //Route pre ID's
        public const string routeAdd = "route/add";
        public const string routeUpdate = "route/update";
        public const string routeDelete = "route/delete";
        public const string routeFollow = "route/follow";
        public const string routeShow = "route/show";
        //Route-Follow pre ID's
        public const string routeFollowSpeed = "route/follow/speed";
        //End of route block.

        //Extra ID's
        public const string empty = "";

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
        private VRResponseHandler responseHandler;
        private VRConnectionHandler _vRConnectionHandler;
        private const int maxRetry = 3;
		private List<VRResponse> _responses;

		public VRHelper()
        {
            responseHandler = new VRResponseHandler(25);
            _vRConnectionHandler = new VRConnectionHandler("145.48.6.10", 6666);
            _client = _vRConnectionHandler._client;
			_tunnelID = "";//GetTunnelID(GetSessionID(), "");
			_responses = new List<VRResponse>();
        }

		public void AddResponse(VRResponse response)
		{
			this._responses.Add(response);
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

		//private dynamic GetTunnelID(string sessionID, string key)
		//{
		//	dynamic dynamicRequest = new JObject();
		//	dynamicRequest.session = sessionID;
		//	dynamicRequest.key = key;
		//	dynamicRequest = GetIDData(IDOperations.tunnelCreate, dynamicRequest);
		//	VRResponse vRResponse = DoSimpleRequest(dynamicRequest);
		//	return vRResponse.response.data.id;
		//}

		//private string GetSessionID()
		//{
		//	VRResponse vRResponse = DoSimpleRequest(GetSimpleRequest(IDOperations.sessionList));
		//	string sessionID = String.Empty;
		//	foreach (var session in vRResponse.response.data)
		//		if (session.clientinfo.user == Environment.UserName)
		//			sessionID = session.id;
		//	return sessionID;
		//}


		//public static dynamic GetSimpleRequest(string idOperation)
		//{
		//    dynamic request = new JObject();
		//    request.id = idOperation;
		//    return request;
		//}

		//public VRResponse DoSimpleRequest(dynamic request)
		//{
		//    _client.WriteMessage(request);
		//    dynamic response = _client.ReadMessage();
		//    VRResponse vRResponse = new VRResponse(request);
		//    vRResponse.response = response;
		//    return vRResponse;
		//}

		//public VRResponse DoVRRequest(dynamic request)
		//{
		//    dynamic fullRequest = GetRequestDynamic(request);
		//    return DoSimpleRequest(request);
		//}



	}
}
