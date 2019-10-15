using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorApp
{
    class SpeedDataPoint
    {
        public DateTime timestamp { get; set; }
        public double speedData { get; set; }

        public SpeedDataPoint(DateTime timestamp, double speedData)
        {
            this.timestamp = timestamp;
            this.speedData = speedData;
        }
    }
}
