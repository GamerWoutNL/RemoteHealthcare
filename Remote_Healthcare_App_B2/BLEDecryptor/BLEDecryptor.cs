using Avans.TI.BLE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    public abstract class BLEDecryptor
    {
        public const bool printChecksum = false;

        public static void Decrypt(byte[] rawData, BLEDataHandler bLEDataHandler) { }

        protected static bool CheckXorValue(byte[] data, byte[] checksum)
        {
            int xorValue = 0;
            for (int i = 0; i < data.Length - 1; i++)
                xorValue ^= data[i];
            if (printChecksum)
                Console.WriteLine($"Xorvalue: {xorValue} Checksum: {data[data.Length - 1]}");
            return xorValue == data[data.Length - 1];
        }
    }
}