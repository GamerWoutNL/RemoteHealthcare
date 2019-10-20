using Newtonsoft.Json.Linq;

namespace Sprint2VR.VR.Components
{
	public class VRPoint2D : VRComponent
	{
		public double posx, posy;

		public VRPoint2D(double posx, double posy)
		{
			this.posx = posx;
			this.posy = posy;
		}

		public override dynamic GetDynamic()
		{
			return new
			{
				position = new JArray(this.posx, this.posy)
			};
		}
	}
}
