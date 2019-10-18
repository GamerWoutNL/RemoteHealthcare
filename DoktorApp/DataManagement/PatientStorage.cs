using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DoktorApp.Data_Management
{
    public class PatientStorage
    {

        public string PatientName { get; set; }
        public string PatientNumber { get; set; }

        public string ergoId { get; set; }
        public List<CustomDatapoint> HeartrateDataPoints { get; set; }
        public List<Chart> HeartrateChartsListeningForUpdates { get; set; }
        public List<CustomDatapoint> SpeedDataPoints { get; set; }
        public List<Chart> SpeedChartsListeningForUpdates { get; set; }
        public List<CustomDatapoint> DistanceDataPoints { get; set; }
        public List<Chart> DistanceChartsListeningForUpdates { get; set; }
        public List<CustomDatapoint> InstantaniousCadenceDataPoints { get; set; }
        public List<Chart> InstantaniousCadenceChartsListeningForUpdates { get; set; }
        public List<CustomDatapoint> AccumulatedPowerDataPoints { get; set; }
        public List<Chart> AccumulatedPowerChartsListeningForUpdates { get; set; }
        public List<CustomDatapoint> InstantaniousPowerDataPoints { get; set; }
        public List<Chart> InstantaniousPowerChartsListeningForUpdates { get; set; }
        public List<double> EventCountDatapoints { get; set; }

        public PatientStorage(string patientName, string patientNumber, string ergoId)
        {
            PatientName = patientName;
            PatientNumber = patientNumber;
            this.ergoId = ergoId;

            this.HeartrateDataPoints = new List<CustomDatapoint>();
            this.SpeedDataPoints = new List<CustomDatapoint>();
            this.DistanceDataPoints = new List<CustomDatapoint>();
            this.InstantaniousCadenceDataPoints = new List<CustomDatapoint>();
            this.AccumulatedPowerDataPoints = new List<CustomDatapoint>();
            this.InstantaniousPowerDataPoints = new List<CustomDatapoint>();
            this.EventCountDatapoints = new List<double>();

            this.HeartrateChartsListeningForUpdates = new List<Chart>();
            this.SpeedChartsListeningForUpdates = new List<Chart>();
            this.DistanceChartsListeningForUpdates = new List<Chart>();
            this.InstantaniousCadenceChartsListeningForUpdates = new List<Chart>();
            this.AccumulatedPowerChartsListeningForUpdates = new List<Chart>();
            this.InstantaniousPowerChartsListeningForUpdates = new List<Chart>();
        }

        private void addData(string timestamp, string data, List<CustomDatapoint> list)
        {
            if (data != null)
            {
                list.Add(new CustomDatapoint(DateTime.Parse(timestamp), Double.Parse(data)));
            }
        }

        public void AddHeartrateDataPoint(string timestamp, string data)
        {
            addData(timestamp, data, this.HeartrateDataPoints);
            foreach(Chart chart in this.HeartrateChartsListeningForUpdates)
            {
                ChartUtils.updateChart(chart, this.HeartrateDataPoints);
            }
        }

        public void AddSpeedDataPoint(string timestamp, string data)
        {
            addData(timestamp, data, this.SpeedDataPoints);
            foreach (Chart chart in this.SpeedChartsListeningForUpdates)
            {
                ChartUtils.updateChart(chart, this.SpeedDataPoints);
            }
        }

        public void AddDistanceDataPoint(string timestamp, string data)
        {
            addData(timestamp, data, this.DistanceDataPoints);
            foreach (Chart chart in this.DistanceChartsListeningForUpdates)
            {
                ChartUtils.updateChart(chart, this.DistanceDataPoints);
            }
        }

        public void AddInstantaniousCadenceDataPoint(string timestamp, string data)
        {
            addData(timestamp, data, this.InstantaniousCadenceDataPoints);
            foreach (Chart chart in this.InstantaniousCadenceChartsListeningForUpdates)
            {
                ChartUtils.updateChart(chart, this.InstantaniousCadenceDataPoints);
            }
        }

        public void AddAccumulatedPowerDataPoint(string timestamp, string data)
        {
            addData(timestamp, data, this.AccumulatedPowerDataPoints);
            foreach (Chart chart in this.AccumulatedPowerChartsListeningForUpdates)
            {
                ChartUtils.updateChart(chart, this.AccumulatedPowerDataPoints);
            }
        }

        public void AddInstantaniousPowerDataPoint(string timestamp, string data)
        {
            addData(timestamp, data, this.InstantaniousPowerDataPoints);
            foreach (Chart chart in this.InstantaniousPowerChartsListeningForUpdates)
            {
                ChartUtils.updateChart(chart, this.InstantaniousPowerDataPoints);
            }
        }

        public void AddEventCountDataPoint(string timestamp, string data)
        {
            this.EventCountDatapoints.Add(Double.Parse(data));
        }
        
        public bool PatientHasDataAlready(string eventCount)
        {
            return this.EventCountDatapoints.Contains(Double.Parse(eventCount));
        }
        
        private void AddListeningChart(Chart chart, List<Chart> charts)
        {
            charts.Add(chart);
        }

        public void AddListeningHeartrateChart(Chart chart)
        {
            AddListeningChart(chart, this.HeartrateChartsListeningForUpdates);
        }

        public void AddListeningSpeedChart(Chart chart)
        {
            AddListeningChart(chart, this.SpeedChartsListeningForUpdates);
        }

        public void AddListeningDistanceChart(Chart chart)
        {
            AddListeningChart(chart, this.DistanceChartsListeningForUpdates);
        }

        public void AddListeningInstantaniousCadenceChart(Chart chart)
        {
            AddListeningChart(chart, this.InstantaniousCadenceChartsListeningForUpdates);
        }

        public void AddListeningAccumulatedPowerChart(Chart chart)
        {
            AddListeningChart(chart, this.AccumulatedPowerChartsListeningForUpdates);
        }

        public void AddListeningInstantaniousPowerChart(Chart chart)
        {
            AddListeningChart(chart, this.InstantaniousPowerChartsListeningForUpdates);
        }
    }
}
