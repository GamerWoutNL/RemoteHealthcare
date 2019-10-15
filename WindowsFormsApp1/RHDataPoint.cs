using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    class RHDataPoint
    { 

        public double XValue { get; set; }
        public double[] YValues { get; set; }
        public bool isEmpty { get; set; }
        public string Name { get; set; }
        public DateTime timestamp { get; set; }

        public RHDataPoint()
        {

        }

        public RHDataPoint(DateTime timestamp)
        {
            this.timestamp = timestamp;
        }

        public RHDataPoint(double xValue, double yValue, DateTime timestamp)
        {
            XValue = xValue;
            this.YValues = new double[1];
            this.YValues[0] = yValue;
            this.timestamp = timestamp;
        }
    }
}
