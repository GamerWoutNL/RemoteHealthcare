using Avans.TI.BLE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    /// <summary>
    /// The WriteOption enumeration defines two options to help identify actions. These are Ergo and Heartrate.
    /// </summary>
    public enum WriteOption
    {
        Ergo, Heartrate
    }

    /// <summary>
    /// BLESimulator replicates data output by using a 1 : 1 copy of a team member cycling on the ergometer.
    /// </summary>
    public class BLESimulator
    {
        private List<byte[]> _bytesErgo = new List<byte[]>();
        private List<byte[]> _bytesHeartRate = new List<byte[]>();
        private string ergoID;

        /// <summary>
        /// The ergoID is needed to define the save location of the Ergometer data.
        /// </summary>
        /// <param name="ergoID"></param>
        public BLESimulator(string ergoID)
        {
            this.ergoID = ergoID;
        }

        /// <summary>
        /// Run the simulator with a data transfer time of 4Hz, just like the real protocol.
        /// </summary>

        public void RunSimulator()
        {
            BLEDataHandler bLEDataHandler = new BLEDataHandler(ergoID);
            int i = 0;
            List<byte[]> data = new List<byte[]>();
            while (true)
            {
                data = ReadData(ApplicationSettings.GetReadWritePath(ergoID), WriteOption.Ergo);
                System.Threading.Thread.Sleep(250);
                BLEDecoderErgo.Decrypt(data[i], bLEDataHandler);
                if (i >= data.Count - 1)
                    i = 0;
                i++;
                string toSend = bLEDataHandler.ReadLastData(); // Data that should be send to the client.
            }
        }

        /// <summary>
        /// Save bytes for record purposes of Ergometer.
        /// </summary>
        /// <param name="data"></param>
        public void SaveBytesErgo(byte[] data)
        {
            _bytesErgo.Add(data);
        }

        /// <summary>
        /// Save bytes for record purposes of heart rate monitor.
        /// </summary>
        /// <param name="data"></param>
        public void SaveBytesHeartRate(byte[] data)
        {
            _bytesHeartRate.Add(data);
        }

        /// <summary>
        /// Read data for simulating purposes. Returns a list of byte[] of data.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ergoOrHeartRate"></param>
        /// <returns></returns>
        public List<byte[]> ReadData(string filePath, WriteOption ergoOrHeartRate)
        {
            filePath = GetErgoHeartRatePath(filePath, ergoOrHeartRate);
            List<Byte[]> deSerializedObject = ReadToFileBinary<List<Byte[]>>(filePath);
            return deSerializedObject;
        }

        /// <summary>
        /// Read in a file and receive a binary desiralization.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pathToFile"></param>
        /// <returns></returns>
        private static T ReadToFileBinary<T>(string pathToFile)
        {
            using (System.IO.Stream stream = System.IO.File.Open(pathToFile, System.IO.FileMode.Open))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// Write to file, writeOption is needed to define the path.
        /// </summary>
        /// <param name="writeOption"></param>
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
        /// <summary>
        /// Receive the Ergometer or Heart rate data path.
        /// </summary>
        /// <param name="pathToFile"></param>
        /// <param name="ergoOrHeartRate"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Write binary data to a file (serialize).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pathToFile"></param>
        /// <param name="objectToWrite"></param>
        /// <param name="newFile"></param>
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
