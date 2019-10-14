using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR.Components
{
    public class VRPoint3D : VRComponent
    {
        public double posx, posy, posz;

        public VRPoint3D(double posx, double posy, double posz)
        {
            this.posx = posx;
            this.posy = posy;
            this.posz = posz;
        }

        public bool IsEqualTo(VRPoint3D vRPoint3D)
        {
            double posxCopy = (Math.Round((posx * 100))) / 100;
            double posyCopy = (Math.Round((posy * 100))) / 100;
            double poszCopy = (Math.Round((posz * 100))) / 100;
            double posxVal = (Math.Round((vRPoint3D.posx * 100))) / 100;
            double posyVal = (Math.Round((vRPoint3D.posy * 100))) / 100;
            double poszVal = (Math.Round((vRPoint3D.posz * 100))) / 100;
            return (posxCopy == posxVal) && (posyCopy == posyVal) && (poszCopy == poszVal);
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
