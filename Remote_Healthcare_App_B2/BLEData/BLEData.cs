using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    [Serializable]
    abstract public class BLEData
    {
        private double[] data;

        public BLEData(double[] data)
        {
            this.data = data; 
        }

        public abstract void printData();
       

        
    }
}
