using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorApp.Data_Management
{
    class PatientStorage
    {

        public string PatientName { get; set; }
        public string PatientNumber { get; set; }
        public List<CustomDatapoint> HeartrateDataPoints { get; set; }
        public List<CustomDatapoint> speedDataPoints { get; set; }
        public List<CustomDatapoint> DistanceDataPoints { get; set; }
        public List<CustomDatapoint> InstantaniousCadenceDataPoints { get; set; }
        public List<CustomDatapoint> AccumulatedPowerDataPoints { get; set; }
        public List<CustomDatapoint> InstantaniousPowerDataPoints { get; set; }

        public PatientStorage(string patientName, string patientNumber)
        {
            PatientName = patientName;
            PatientNumber = patientNumber;

            this.HeartrateDataPoints = new List<CustomDatapoint>();
            this.speedDataPoints = new List<CustomDatapoint>();
            this.DistanceDataPoints = new List<CustomDatapoint>();
            this.InstantaniousCadenceDataPoints = new List<CustomDatapoint>();
            this.AccumulatedPowerDataPoints = new List<CustomDatapoint>();
            this.InstantaniousPowerDataPoints = new List<CustomDatapoint>();
        }

        private void addData(string timestamp, string data, List<CustomDatapoint> list)
        {
            list.Add(new CustomDatapoint(DateTime.Parse(timestamp), Double.Parse(data)));
        }

        public void AddHeartrateDataPoint(string timestamp, string data)
        {
            addData(timestamp, data, this.HeartrateDataPoints);
        }

        public void AddSpeedDataPoint(string timestamp, string data)
        {
            addData(timestamp, data, this.speedDataPoints);
        }

        public void AddDistanceDataPoint(string timestamp, string data)
        {
            addData(timestamp, data, this.DistanceDataPoints);
        }

        public void AddInstantaniousCadenceDataPoint(string timestamp, string data)
        {
            addData(timestamp, data, this.InstantaniousCadenceDataPoints);
        }

        public void AddAccumulatedPowerDataPoint(string timestamp, string data)
        {
            addData(timestamp, data, this.AccumulatedPowerDataPoints);
        }

        public void AddInstantaniousPowerDataPoint(string timestamp, string data)
        {
            addData(timestamp, data, this.InstantaniousPowerDataPoints);
        }
        

        

    }
}
