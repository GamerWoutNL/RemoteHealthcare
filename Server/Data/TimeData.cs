using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data
{
    public class TimeData
    {
        private string time;
        private string data;

        public TimeData(string data, string time)
        {
            this.time = time;
            this.data = data;
        }
    }
}
