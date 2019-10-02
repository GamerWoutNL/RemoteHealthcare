using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR.Additional
{
    public class VRResponse
    {
        public dynamic request { get; }
        public dynamic response { get; set;  }

        public VRResponse(dynamic request)
        {
            this.request = request;
            this.response = response;
        }

        public override string ToString()
        {
            return $"Request: {request}\r\nResponse: {this.response}";
        }
    }
}
