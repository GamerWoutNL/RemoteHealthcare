using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR.Components
{
    class VRAnimation : VRComponent
    {
        public string name;
        public double speed;

        public VRAnimation(string name, double speed)
        {
            this.name = name;
            this.speed = speed;
        }

        public override dynamic GetDynamic()
        {
            return new
            {
                animation = new
                {
                    name,
                    speed
                }
            };
        }
    }
}
