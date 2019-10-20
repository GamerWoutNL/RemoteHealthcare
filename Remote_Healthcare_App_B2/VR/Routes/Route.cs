using Sprint2VR.VR.Components;

namespace VREngine.Routes
{
	public class Route
	{
		public VRPoint3D EndPos { get; set; }
		public VRPoint3D Rotation { get; set; }
		public double ResistancePenalty { get; set; }

		public Route(VRPoint3D endPos, VRPoint3D rotation, double resistancePenalty)
		{
			this.EndPos = endPos;
			this.ResistancePenalty = resistancePenalty;
			this.Rotation = rotation;
		}
	}
}
