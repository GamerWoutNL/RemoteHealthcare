using Newtonsoft.Json.Linq;

namespace Sprint2VR.VR.Components
{
	public class VRPoint3D : VRComponent
	{
		public double posx, posy, posz;

		public VRPoint3D(double posx, double posy, double posz)
		{
			this.posx = posx;
			this.posy = posy;
			this.posz = posz;
		}

		public override dynamic GetDynamic()
		{
			return new
			{
				position = new JArray(this.posx, this.posy, this.posz)
			};
		}
	}
}
