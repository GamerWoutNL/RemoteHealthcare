using Newtonsoft.Json.Linq;

namespace Sprint2VR.VR.Components
{
	public class VRModel : VRComponent
	{
		public string fileName;
		public bool cullBackFaces;
		public bool animated;
		public string animation;

		public VRModel(string filename, bool cullbackfaces, bool animated, string animation)
		{
			this.fileName = filename;
			this.cullBackFaces = cullbackfaces;
			this.animated = animated;
			this.animation = animation;
		}

		public override dynamic GetDynamic()
		{
			dynamic request = new JObject();
			dynamic model = new JObject();
			model.file = this.fileName;
			if (this.cullBackFaces != false)
			{
				model.cullbackfaces = this.cullBackFaces;
			}

			if (this.animated != false)
			{
				model.animated = this.animated;
			}

			if (this.animation != null)
			{
				model.animation = this.animation;
			}

			request.model = model;
			return request;
			//return new
			//{
			//    model = new
			//    {
			//        file = fileName,
			//        cullbackfaces = cullBackFaces,
			//        animated,
			//        animation
			//    }
			//};
		}
	}
}
