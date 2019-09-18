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
            return new
            {
                model = new
                {
                    file = fileName,
                    cullbackfaces = cullBackFaces,
                    animated,
                    animation
                }
            };
        }
    }
}
