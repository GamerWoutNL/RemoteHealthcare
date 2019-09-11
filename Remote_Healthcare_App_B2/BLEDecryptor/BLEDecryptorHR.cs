using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    class BLEDecryptorHR : BLEDecryptor
    {
        public static void Decrypt(byte[] rawData, BLEDataHandler bLEDataHandler)
        {
          ;
            //byte[] checksum = { rawData[rawData.Length - 1] };
            //bool isCorrect = CheckXorValue(rawData, checksum);

            int heartRate = rawData[1];
            bLEDataHandler.SetHeartrate(heartRate);
        }

    }
}
