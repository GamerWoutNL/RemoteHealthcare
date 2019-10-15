using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorApp
{
    class HeartrateDatapoint
    {
        public DateTime timestamp { get; set; }
        public int heartrateData { get; set; }

        public HeartrateDatapoint(DateTime timestamp, int heartrateData)
        {
            this.timestamp = timestamp;
            this.heartrateData = heartrateData;
        }
    }
}
