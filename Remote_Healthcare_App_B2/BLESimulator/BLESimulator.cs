using Avans.TI.BLE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    public enum WriteOption
    {
        Ergo, Heartrate
    }
    public class BLESimulator
    {
        private List<byte[]> _bytesErgo = new List<byte[]>();
        private List<byte[]> _bytesHeartRate = new List<byte[]>();
        private string ergoID;
        public BLESimulator(string ergoID)
        {
            this.ergoID = ergoID;
            //_bytesErgo = ReadData(ApplicationSettings.GetReadWritePath(ergoID), WriteOption.Ergo);
            //_bytesHeartRate = ReadData(ApplicationSettings.GetReadWritePath(ergoID), WriteOption.Heartrate);
        }

        public void RunSimulator()
        {
            BLEDataHandler bLEDataHandler = new BLEDataHandler(ergoID);
            int i = 0;
            List<byte[]> data = new List<byte[]>();
            while (true)
            {
                data = ReadData(ApplicationSettings.GetReadWritePath(ergoID), WriteOption.Ergo);
                System.Threading.Thread.Sleep(250);
                BLEDecryptorErgo.Decrypt(data[i], bLEDataHandler);
                if (i >= data.Count - 1)
                    i = 0;
                i++;
            }
        }

        public void SaveBytesErgo(byte[] data)
        {
            _bytesErgo.Add(data);
        }

        public void SaveBytesHeartRate(byte[] data)
        {
            _bytesHeartRate.Add(data);
        }

        private List<byte[]> ReadData(string filePath, WriteOption ergoOrHeartRate)
        {
            filePath = GetErgoHeartRatePath(filePath, ergoOrHeartRate);
            List<Byte[]> deSerializedObject = ReadToFileBinary<List<Byte[]>>(filePath);
            return deSerializedObject;
        }

        private static T ReadToFileBinary<T>(string pathToFile)
        {
            using (System.IO.Stream stream = System.IO.File.Open(pathToFile, System.IO.FileMode.Open))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        public void WriteData(WriteOption writeOption)
        {
            string pathToFile = GetErgoHeartRatePath(ApplicationSettings.GetReadWritePath(ergoID), writeOption);
            List<byte[]> dataToWrite = new List<byte[]>();
            switch (writeOption)
            {
                case WriteOption.Ergo:
                    dataToWrite = _bytesErgo;
                    break;
                case WriteOption.Heartrate:
                    dataToWrite = _bytesHeartRate;
                    break;

            }
            writeToFileBinary(pathToFile, dataToWrite);
        }

        private static string GetErgoHeartRatePath(string pathToFile, WriteOption ergoOrHeartRate)
        {
            string newPath = pathToFile;
            switch (ergoOrHeartRate)
            {
                case WriteOption.Ergo:
                    newPath += "_Ergometer";
                    break;
                case WriteOption.Heartrate:
                    newPath += "_HRMonitor";
                    break;
            }
            return newPath;
        }

        private static void writeToFileBinary<T>(string pathToFile, T objectToWrite, bool newFile = false)
        {
            Console.WriteLine("Path: " + pathToFile);
            
            using (System.IO.Stream stream = System.IO.File.Open(pathToFile, newFile ? System.IO.FileMode.Create : System.IO.File.Exists(pathToFile) ? System.IO.FileMode.Truncate : System.IO.FileMode.Create))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }

        }
    }
}
