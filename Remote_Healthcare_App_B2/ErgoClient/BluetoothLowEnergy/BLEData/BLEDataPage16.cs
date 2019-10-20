using Server;
using System;

namespace ErgoConnect
{
	/// <summary>
	/// BLEDataPage16 class contains specific data which is received by BLE. This is part of a specific protocol. This class contains elapsed time, distance travelled, speed and heart rate.
	/// </summary>
	[Serializable]
	public class BLEDataPage16 : BLEData
	{
		public double elapsedTime { get; }
		public double distanceTravelled { get; }
		public double speed { get; }
		public double heartRate { get; }

		/// <summary>
		/// Receives data upon constructing, and saves this for later purpose by calling its base class.
		/// </summary>
		/// <param name="data"></param>
		public BLEDataPage16(double[] data) : base(data)
		{
			this.elapsedTime = data[0];
			this.distanceTravelled = data[1];
			this.speed = data[2];
			this.heartRate = data[3];
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
			return $"<{Tag.ET.ToString()}>{this.elapsedTime}<{Tag.DT.ToString()}>{this.distanceTravelled}<{Tag.SP.ToString()}>{this.speed}<{Tag.HR.ToString()}>{this.heartRate}";
		}
	}
}
