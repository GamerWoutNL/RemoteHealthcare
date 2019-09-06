using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    public class Simulator
    {
        private BLEDataHandler dataHandler;
        public Simulator()
        {
            this.dataHandler = new BLEDataHandler("00472");
            BLEData data = this.readData(dataHandler.GetReadWritePath());
            data.printData();
        }

        private BLEData readData(string filePath)
        {
            BLEData deSerializedObject = readToFileBinary<BLEData>(filePath);
            return deSerializedObject;
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
