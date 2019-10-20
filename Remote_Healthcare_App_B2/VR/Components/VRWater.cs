namespace Sprint2VR.VR.Components
{
	public class VRWater : VRComponent
	{
		public VRPoint2D size;
		public double resolution;

		public VRWater(VRPoint2D size, double resolution)
		{
			this.size = size;
			this.resolution = resolution;
		}

		public override dynamic GetDynamic()
		{
			return new
			{
				water = new
				{
					size = this.size.GetDynamic().position,
					this.resolution
				}
			};
		}
	}
}
