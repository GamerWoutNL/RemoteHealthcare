namespace Sprint2VR.VR.Components
{
	public class VRTerrain : VRComponent
	{
		public bool smoothNormals;

		public VRTerrain(bool smoothNormals)
		{
			this.smoothNormals = smoothNormals;
		}

		public override dynamic GetDynamic()
		{
			return new
			{
				terrain = new
				{
					smoothnormals = this.smoothNormals
				}
			};
		}
	}
}
