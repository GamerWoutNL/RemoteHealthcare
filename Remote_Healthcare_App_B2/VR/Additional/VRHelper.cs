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
}
