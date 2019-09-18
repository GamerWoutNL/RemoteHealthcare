using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR.Components
{
    class VRTransform : VRComponent
    {
        public VRPositionXYZ positionXYZ; // position
        public VRPositionXYZ rotationXYZ; // rotation
        public double scale; // scale

        public VRTransform(VRPositionXYZ positionXYZ, VRPositionXYZ rotationXYZ, double scale)
        {
            this.positionXYZ = positionXYZ;
            this.rotationXYZ = rotationXYZ;
            this.scale = scale;
        }

        public override dynamic GetDynamic()
        {
            return new
            {
                transform = new
                {
                    positionXYZ.GetDynamic().position,
                    scale,
                    rotation = rotationXYZ.GetDynamic().position
                }
            };
        }
    }
}
