using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    [Serializable]
    public class BLEDataPage25 : BLEData
    {
        private double updateEventCount { get; }
        private double instanteousCadence { get; }
        private double accumulatedPower { get; }
        private double instanteousPower { get; }
        public BLEDataPage25(double[] data) : base(data)
        {
            updateEventCount = data[0];
            instanteousCadence = data[1];
            accumulatedPower = data[2];
            instanteousPower = data[3];
        }

        public override void printData()
        {
            Console.WriteLine($"Count: {Math.Round(this.updateEventCount)}\t\t Cadence: {this.instanteousCadence} rpm\t\t Acc power: {Math.Round(this.accumulatedPower)} Watt\t\t Inst power: {this.instanteousPower} Watt");
        }
    }
}
