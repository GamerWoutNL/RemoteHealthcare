using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    public class BLEDataHandler
    {
        public List<BLEData> _bleData { get; set; }
        private string ergoID;
        private int heartrate;

        public BLEDataHandler(System.String ergometerSerialLastFiveNumbers) // Maybe add simulation interface here as parameter for callback in readData(); which adds data to List<BLEData>
        {
            this._bleData = new List<BLEData>();
            ergoID = ergometerSerialLastFiveNumbers;
            // writeData();
            // DoesExist(GetReadWritePath());
        }

        public void SetHeartrate(int heartrate)
        {
            this.heartrate = heartrate;
        }

        public void addBLEDataForDataPage16(double[] data)
        {
            data[3] = this.heartrate;
            BLEDataPage16 bLEDataPage16 = new BLEDataPage16(data);
            _bleData.Add(bLEDataPage16);
        }

        public void addBLEDataForDataPage25(double[] data)
        {
            BLEDataPage25 bLEDataPage25 = new BLEDataPage25(data);
            _bleData.Add(bLEDataPage25); 
        }

        public void printLastData()
        {
            this._bleData[_bleData.Count - 1].printData();
        }

        public void printAllData()
        {
            for (int i = 0; i < this._bleData.Count; i++)
            {
                this._bleData[i].printData();
                System.Threading.Thread.Sleep(250);

                if (i == this._bleData.Count - 1) i = 0;
            }
        }

        public void readLastData()
        {
            BLEData data = _bleData[_bleData.Count - 1];
            if (data.GetType() == typeof(BLEDataPage16))
            {
                // Action for page 16 data
            } 
            if (data.GetType() == typeof(BLEDataPage25))
            {
                // Action for page 25 data
            }
        }
    }
}
