using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR.Components
{
    public class VRLine : VRComponent
    {
        public VRPoint2D positionXY;
        public VRPoint2D positionXY2;
        public VRColor color;

        public VRLine(VRPoint2D positionXY, VRPoint2D positionXY2, VRColor color)
        {
            this.positionXY = positionXY;
            this.positionXY2 = positionXY2;
            this.color = color;
        }

        public override dynamic GetDynamic()
        {
            return new
            {
                line =
                new JArray(positionXY.posx, positionXY.posy, positionXY2.posx, positionXY2.posy, color.r, color.g, color.b, color.a)
            };
        }
    }
}

