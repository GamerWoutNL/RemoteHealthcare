using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR.Components
{
    class VRModel : VRComponent
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
            model.file = fileName;
            if (cullBackFaces != false)
                model.cullbackfaces = cullBackFaces;
            if (animated != false)
                model.animated = animated;
            if (animation != null)
                model.animation = animation;
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
