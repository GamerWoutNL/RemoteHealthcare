﻿using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VREngine;

namespace ErgoConnect
{
    /// <summary>
    /// The BLEDataHandler class stores _bleData for history purposes (and potentially graphing). It is also supposed to perform an action corresponding on the type of data it receives. However this still must be implemented. 
    /// </summary>
    public class BLEDataHandler
    {
        public List<BLEData> _bleData { get; set; }
        private string ergoID;
        private string patientName;
        private string patientNumber;
        private int heartrate;

        /// <summary>
        /// The constructor needs a serial number. ErgoID is set, so this is known to the class from now on.
        /// </summary>
        /// <param name="ergometerSerialLastFiveNumbers"></param>
        public BLEDataHandler(System.String ergometerSerialLastFiveNumbers, System.String patientName, System.String patientNumber) // Maybe add simulation interface here as parameter for callback in readData(); which adds data to List<BLEData>
        {
            this._bleData = new List<BLEData>();
            this.patientName = patientName;
            this.patientNumber = patientNumber;
            ergoID = ergometerSerialLastFiveNumbers;
        }

        /// <summary>
        /// The SetHeartrate method is used to combine the heart rate data with the Ergometer data in only one class. 
        /// </summary>
        /// <param name="heartrate"></param>

        public void SetHeartrate(int heartrate)
        {
            this.heartrate = heartrate;
        }

        /// <summary>
        /// Data page 16 contains specific data, just as data page 25 contains very different detailed data. A distinction must be made here.
        /// </summary>
        /// <param name="data"></param>
        public void addBLEDataForDataPage16(double[] data)
        {
            data[3] = this.heartrate;
            BLEDataPage16 bLEDataPage16 = new BLEDataPage16(data);
            _bleData.Add(bLEDataPage16);
        }

        /// <summary>
        /// Data page 25 contains specific data, just as data page 16 contains very different detailed data. A distinction must be made here.
        /// </summary>
        /// <param name="data"></param>

        public void addBLEDataForDataPage25(double[] data)
        {
            BLEDataPage25 bLEDataPage25 = new BLEDataPage25(data);
            _bleData.Add(bLEDataPage25);
        }
        /// <summary>
        /// Print the last data stored in the List (hence this is not the same as printing the last _received_ data!).
        /// </summary>
        public void printLastData()
        {
            this._bleData[_bleData.Count - 1].PrintData();
        }

        /// <summary>
        /// Check for instance of BLEData
        /// </summary>

        public string ReadLastData()
        {
            if (_bleData.Count > 0)
            {
                BLEData data = _bleData[_bleData.Count - 1];
                return $"<{Tag.MT.ToString()}>{"data"}<{Tag.TS.ToString()}>{DateTime.Now.ToString("s")}<{Tag.PNA.ToString()}>{patientName}<{Tag.PNU.ToString()}>{patientNumber}<{Tag.ID.ToString()}>{ergoID}{data.GetData()}<{Tag.EOF.ToString()}>";
            }
            else return String.Empty;
        }

        public void UpdateVR(VRHandler vRHandler)
        {
            BLEData bleData = _bleData[_bleData.Count - 1];
            if (bleData is BLEDataPage16)
            {
                Console.WriteLine("UPDATING VR NOW");
                BLEDataPage16 data = (BLEDataPage16)bleData;
                vRHandler.RefreshAndDraw(data.speed.ToString(), data.heartRate.ToString(), "");
            }
        }
    }
}
