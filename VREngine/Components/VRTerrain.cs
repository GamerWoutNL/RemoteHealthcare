using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR.Components
{
    class VRTerrain : VRComponent
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
                    smoothnormals = smoothNormals
                }
            };
        }
    }
}
