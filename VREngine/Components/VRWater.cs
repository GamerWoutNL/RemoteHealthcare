using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR.Components
{
    class VRWater : VRComponent
    {
        public VRPositionXY size;
        public double resolution;

        public VRWater(VRPositionXY size, double resolution)
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
                    size = size.GetDynamic().position,
                    resolution
                }
            };
        }
    }
}
