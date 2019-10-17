using Sprint2VR.VR.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VREngine.Routes
{
    public class Route
    {
        public VRPoint3D endPos { get; set; }
        public VRPoint3D rotation { get; set; }
        public double resistancePenalty { get; set; }

        public Route(VRPoint3D endPos, VRPoint3D rotation, double resistancePenalty)
        {
            this.endPos = endPos;
            this.resistancePenalty = resistancePenalty;
            this.rotation = rotation;
        }
    }
}
