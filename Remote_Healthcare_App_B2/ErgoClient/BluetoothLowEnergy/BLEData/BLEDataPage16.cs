using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    /// <summary>
    /// BLEDataPage16 class contains specific data which is received by BLE. This is part of a specific protocol. This class contains elapsed time, distance travelled, speed and heart rate.
    /// </summary>
    [Serializable]
    public class BLEDataPage16 : BLEData
    {
        private double elapsedTime { get; }
        private double distanceTravelled { get; }
        private double speed { get; }
        private double heartRate { get; }

        /// <summary>
        /// Receives data upon constructing, and saves this for later purpose by calling its base class.
        /// </summary>
        /// <param name="data"></param>
        public BLEDataPage16(double[] data) : base(data)
        {
            elapsedTime = data[0];
            distanceTravelled = data[1];
            speed = data[2];
            heartRate = data[3];
        }

        /// <summary>
        /// Implementation of printing data to the console.
        /// </summary>
        public override void PrintData()
        {
            Console.WriteLine($"Elapsed Time: {Math.Round(this.elapsedTime)} sec\t\t Distance: {this.distanceTravelled} m\t\t Speed: {Math.Round(this.speed)} kmph\t\t Heart rate: {this.heartRate} bpm");
        }

        public override string GetData()
        {
            return $"<{Tag.ET.ToString()}>{elapsedTime}<{Tag.DT.ToString()}>{distanceTravelled}<{Tag.SP.ToString()}>{speed}<{Tag.HR.ToString()}>{heartRate}";
        }
    }
}
