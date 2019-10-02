using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data
{
    public class TimeData
    {
        public string time { get; }
        public string data { get; }

		public TimeData(string data, string time)
        {
            this.time = time;
            this.data = data;
        }
    }
}
