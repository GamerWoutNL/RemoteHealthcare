using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    /// <summary>
    /// BLEDataPage25 contains specific data which is received by BLE.  This is part of a specific protocol. This class contains update event count, cadence, accumulated power and instanteous power.
    /// </summary>
    [Serializable]
    public class BLEDataPage25 : BLEData
    {
        private double updateEventCount { get; }
        private double instanteousCadence { get; }
        private double accumulatedPower { get; }
        private double instanteousPower { get; }
        /// <summary>
        /// Receives data upon constructing, and saves this for later purpose by calling its base class.
        /// </summary>
        /// <param name="data"></param>
        public BLEDataPage25(double[] data) : base(data)
        {
            updateEventCount = data[0];
            instanteousCadence = data[1];
            accumulatedPower = data[2];
            instanteousPower = data[3];
        }
        /// <summary>
        /// Implementation of printing data to the console.
        /// </summary>
        public override void printData()
        {
            Console.WriteLine($"Count: {Math.Round(this.updateEventCount)}\t\t Cadence: {this.instanteousCadence} rpm\t\t Acc power: {Math.Round(this.accumulatedPower)} Watt\t\t Inst power: {this.instanteousPower} Watt");
        }
    }
}
