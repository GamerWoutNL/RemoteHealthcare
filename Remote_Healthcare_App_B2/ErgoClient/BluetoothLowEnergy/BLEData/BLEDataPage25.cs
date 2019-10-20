using Server;
using System;

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
			this.updateEventCount = data[0];
			this.instanteousCadence = data[1];
			this.accumulatedPower = data[2];
			this.instanteousPower = data[3];
		}
		/// <summary>
		/// Implementation of printing data to the console.
		/// </summary>
		public override void PrintData()
		{
			Console.WriteLine($"Count: {Math.Round(this.updateEventCount)}\t\t Cadence: {this.instanteousCadence} rpm\t\t Acc power: {Math.Round(this.accumulatedPower)} Watt\t\t Inst power: {this.instanteousPower} Watt");
		}

		public override string GetData()
		{
			return $"<{Tag.EC.ToString()}>{this.updateEventCount}<{Tag.IC.ToString()}>{this.instanteousCadence}<{Tag.AP.ToString()}>{this.accumulatedPower}<{Tag.IP.ToString()}>{this.instanteousPower}";
		}
	}
}
