using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR.Components
{
    class VRTransform : VRComponent
    {
        public VRPoint3D positionXYZ; // position
        public VRPoint3D rotationXYZ; // rotation
        public double scale; // scale

        public VRTransform(VRPoint3D positionXYZ, VRPoint3D rotationXYZ, double scale)
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
