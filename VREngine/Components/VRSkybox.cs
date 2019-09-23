using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR.Components
{
    enum SkyboxType
    {
        @static, dynamic
    }
    class VRSkybox : VRComponent
    {
        private SkyboxType skyboxType = SkyboxType.dynamic;
        private string xpos, xneg, ypos, yneg, zpos, zneg;

        public override dynamic GetDynamic()
        {
            dynamic dynamicRequest = new JObject();
            dynamicRequest.type = skyboxType.ToString();
            if (skyboxType==SkyboxType.@static)
            {
                dynamic files = new JObject();
                files.xpos = xpos;
                files.xneg = xneg;
                files.ypos = ypos;
                files.yneg = yneg;
                files.zpos = zpos;
                files.zneg = zneg;
                dynamicRequest.files = files;
                //dynamicRequest.files = new
                //{
                //    xpos, xneg, ypos, yneg, zpos, zneg
                //};
            }
            return dynamicRequest;
        }

        public void SetCustomSkybox(string xpos, string xneg, string ypos, string yneg, string zpos, string zneg)
        {
            skyboxType = SkyboxType.@static;
            this.xpos = xpos;
            this.xneg = xneg;
            this.ypos = ypos;
            this.yneg = yneg;
            this.zpos = zpos;
            this.zneg = zneg;
        }

        
    }
}
