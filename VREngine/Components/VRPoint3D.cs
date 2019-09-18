using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR.Components
{
    class VRPositionXYZ : VRComponent
    {
        double posx, posy, posz;

        public VRPositionXYZ(double posx, double posy, double posz)
        {
            this.posx = posx;
            this.posy = posy;
            this.posz = posz;
        }

        public override dynamic GetDynamic()
        {
            return new
            {
                position = new JArray(posx, posy, posz)
            };
        }
    }
}
