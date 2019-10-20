using Newtonsoft.Json.Linq;

namespace Sprint2VR.VR.Components
{
	public enum SkyboxType
	{
		@static, dynamic
	}
	public class VRSkybox : VRComponent
	{
		private SkyboxType skyboxType = SkyboxType.dynamic;
		private string xpos, xneg, ypos, yneg, zpos, zneg;

		public override dynamic GetDynamic()
		{
			dynamic dynamicRequest = new JObject();
			dynamicRequest.type = this.skyboxType.ToString();
			if (this.skyboxType == SkyboxType.@static)
			{
				dynamic files = new JObject();
				files.xpos = this.xpos;
				files.xneg = this.xneg;
				files.ypos = this.ypos;
				files.yneg = this.yneg;
				files.zpos = this.zpos;
				files.zneg = this.zneg;
				dynamicRequest.files = files;
				//dynamicRequest.files = new
				//{
				//    xpos, xneg, ypos, yneg, zpos, zneg
				//};
			}
			return dynamicRequest;
		}

		public void SetCustomSkybox(string xpos, string xneg, string ypos, string yneg, string zpos, string zneg)
		{
			this.skyboxType = SkyboxType.@static;
			this.xpos = xpos;
			this.xneg = xneg;
			this.ypos = ypos;
			this.yneg = yneg;
			this.zpos = zpos;
			this.zneg = zneg;
		}


	}
}
