﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    [Serializable]
    public class BLEDataPage16 : BLEData
    {
        private double elapsedTime { get; }
        private double distanceTravelled { get; }
        private double speed { get; }
        private double heartRate { get; }
        public BLEDataPage16(double[] data) : base(data)
        {
            elapsedTime = data[0];
            distanceTravelled = data[1];
            speed = data[2];
            heartRate = data[3];
        }

        public override void printData()
        {
            Console.WriteLine($"Elapsed Time: {Math.Round(this.elapsedTime)} sec\t\t Distance: {this.distanceTravelled} m\t\t Speed: {Math.Round(this.speed)} kmph\t\t Heart rate: {this.heartRate} bpm");
        }
    }
}
