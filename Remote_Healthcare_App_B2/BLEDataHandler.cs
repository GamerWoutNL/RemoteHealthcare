using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    public class BLEDataHandler
    {
        private List<BLEData> _bleData = new List<BLEData>();
        private string ergoID;
        private int heartrate;

        public BLEDataHandler(System.String ergometerSerialLastFiveNumbers) // Maybe add simulation interface here as parameter for callback in readData(); which adds data to List<BLEData>
        {
            ergoID = ergometerSerialLastFiveNumbers;
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

        public void readLastData()
        {
            BLEData data = _bleData[_bleData.Count - 1];
            data.printData();
            if (data.GetType() == typeof(BLEDataPage16))
            {
               
            } 
            if (data.GetType() == typeof(BLEDataPage25))
            {

            }
        }

        public void readData()
        {
            List<BLEData> deSerializedObject = readToFileBinary<List<BLEData>>(GetReadWritePath());
            this._bleData = deSerializedObject;
        }

        private string GetReadWritePath()
        {
           return $"{ApplicationSettings.GetSaveDirectory()}/activitylog_{ergoID}"; 
        }

        public void writeData()
        {
            writeToFileBinary(GetReadWritePath(), _bleData);
        }

        private static void writeToFileBinary<T>(string pathToFile, T objectToWrite, bool newFile = true)
        {
            using (System.IO.Stream stream = System.IO.File.Open(pathToFile, newFile ? System.IO.FileMode.Create : System.IO.FileMode.Create)) // Was Append
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        private static T readToFileBinary<T>(string pathToFile)
        {
            using (System.IO.Stream stream = System.IO.File.Open(pathToFile, System.IO.FileMode.Open))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
