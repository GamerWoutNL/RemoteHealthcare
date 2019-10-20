namespace Sprint2VR.VR.Components
{
	public class VRAnimation : VRComponent
	{
		public string name;
		public double speed;

		public VRAnimation(string name, double speed)
		{
			this.name = name;
			this.speed = speed;
		}

		public override dynamic GetDynamic()
		{
			return new
			{
				animation = new
				{
					this.name,
					this.speed
				}
			};
		}
	}
}
