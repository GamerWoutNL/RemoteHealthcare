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
            DoesExist(GetReadWritePath());
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
               
            } 
            if (data.GetType() == typeof(BLEDataPage25))
            {

            }
        }

        public string GetReadWritePath()
        {
           //return $"{ApplicationSettings.GetSaveDirectory()}/activitylog";
           return $"{ApplicationSettings.GetSaveDirectory()}/activitylog_{ergoID}";
        }

        public void writeData()
        {
            writeToFileBinary(GetReadWritePath(), _bleData);
        }

        private static void DoesExist(string pathToFile)
        {
            if (!System.IO.File.Exists(pathToFile))
            {
                System.IO.Stream stream = System.IO.File.Open(pathToFile, System.IO.FileMode.Create);
                //System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                //binaryFormatter.Serialize(stream, null);
            }
            
        }

        private static void writeToFileBinary<T>(string pathToFile, T objectToWrite, bool newFile = false)
        {
            //using (System.IO.Stream stream = System.IO.File.Open(pathToFile, newFile ? System.IO.FileMode.Create : System.IO.FileMode.Truncate)) // Was Append
            //{
            //    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //    binaryFormatter.Serialize(stream, objectToWrite);
            //}

            using (System.IO.Stream stream = System.IO.File.Open(pathToFile, newFile ? System.IO.FileMode.Create : System.IO.FileMode.Truncate)) // Was Append
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }

        }


    }
}
