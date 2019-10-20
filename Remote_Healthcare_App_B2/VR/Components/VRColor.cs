using Newtonsoft.Json.Linq;

namespace Sprint2VR.VR.Components
{
	public class VRColor : VRComponent
	{
		public float r, g, b, a;

		public VRColor(float r, float g, float b, float a)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		public override dynamic GetDynamic()
		{
			return new
			{
				color = new JArray(this.r, this.g, this.b, this.a)
			};
		}
	}
}
