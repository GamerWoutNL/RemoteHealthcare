using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorApp
{
    public class CustomDatapoint
    {

        public DateTime timestamp { get; set; }
        public double data { get; set; }

        public CustomDatapoint(DateTime timestamp, double data)
        {
            this.timestamp = timestamp;
            this.data = data;
        }

    }
}
