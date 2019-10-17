using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VREngine.Additional
{
    interface IRespond
    {
        void HandleResponse(dynamic response);
        dynamic GetResponse(string IDOperation);
    }
}
