using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR.Components
{
    class VRPanel : VRComponent
    {
        public VRPositionXY size; //Size
        public VRPositionXY resolution; //Resolution 
        public VRColor background; //Background
        public bool castShadow; //Cast a shadow

        public VRPanel(VRPositionXY size, VRPositionXY resolution, VRColor background, bool castShadow)
        {
            this.size = size;
            this.resolution = resolution;
            this.background = background;
            this.castShadow = castShadow;
        }

        public override dynamic GetDynamic()
        {
            return new
            {
                panel = new
                {
                    size = size.GetDynamic().position,
                    resolution = resolution.GetDynamic().position,
                    background = background.GetDynamic().color,
                    animation = castShadow
                }
            };
        }
    }
}


