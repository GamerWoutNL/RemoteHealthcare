using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR.Components
{
    public class VRPoint2D : VRComponent
    {
        public double posx, posy;

        public VRPoint2D(double posx, double posy)
        {
            this.posx = posx;
            this.posy = posy;
        }

        public override dynamic GetDynamic()
        {
            return new
            {
                position = new JArray(posx, posy)
            };
        }
    }
}
