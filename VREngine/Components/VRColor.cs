using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR.Components
{
    public class VRColor : VRComponent
    {
        public float r, g, b, a;

        public VRColor(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public override dynamic GetDynamic()
        {
            return new
            {
                color = new JArray(r,g,b,a)
            };
        }
    }
}
