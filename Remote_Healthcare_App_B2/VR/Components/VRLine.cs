using Newtonsoft.Json.Linq;

namespace Sprint2VR.VR.Components
{
	public class VRLine : VRComponent
	{
		public VRPoint2D positionXY;
		public VRPoint2D positionXY2;
		public VRColor color;

		public VRLine(VRPoint2D positionXY, VRPoint2D positionXY2, VRColor color)
		{
			this.positionXY = positionXY;
			this.positionXY2 = positionXY2;
			this.color = color;
		}

		public override dynamic GetDynamic()
		{
			return new
			{
				line =
				new JArray(this.positionXY.posx, this.positionXY.posy, this.positionXY2.posx, this.positionXY2.posy, this.color.r, this.color.g, this.color.b, this.color.a)
			};
		}
	}
}

