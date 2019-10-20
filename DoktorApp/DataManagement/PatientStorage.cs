using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using static DoktorApp.DetailedPatientView;

namespace DoktorApp.Data_Management
{
	public class PatientStorage
	{

		public string PatientName { get; set; }
		public string PatientNumber { get; set; }

		public string ErgoId { get; set; }
		public List<CustomDatapoint> HeartrateDataPoints { get; set; }
		public ConcurrentBag<Chart> HeartrateChartsListeningForUpdates { get; set; }
		public List<CustomDatapoint> SpeedDataPoints { get; set; }
		public ConcurrentBag<Chart> SpeedChartsListeningForUpdates { get; set; }
		public List<CustomDatapoint> DistanceDataPoints { get; set; }
		public ConcurrentBag<Chart> DistanceChartsListeningForUpdates { get; set; }
		public List<CustomDatapoint> InstantaniousCadenceDataPoints { get; set; }
		public ConcurrentBag<Chart> InstantaniousCadenceChartsListeningForUpdates { get; set; }
		public List<CustomDatapoint> AccumulatedPowerDataPoints { get; set; }
		public ConcurrentBag<Chart> AccumulatedPowerChartsListeningForUpdates { get; set; }
		public List<CustomDatapoint> InstantaniousPowerDataPoints { get; set; }
		public ConcurrentBag<Chart> InstantaniousPowerChartsListeningForUpdates { get; set; }
		public List<double> EventCountDatapoints { get; set; }
		public bool MainChartListening { get; set; }
		public string MainChartListeningToData { get; set; }
		public Chart MainChart { get; set; }

		public PatientStorage(string patientName, string patientNumber, string ergoId)
		{
			this.PatientName = patientName;
			this.PatientNumber = patientNumber;
			this.ErgoId = ergoId;
			this.MainChartListening = false;
			this.MainChartListeningToData = "";
			this.MainChart = null;

			this.HeartrateDataPoints = new List<CustomDatapoint>();
			this.SpeedDataPoints = new List<CustomDatapoint>();
			this.DistanceDataPoints = new List<CustomDatapoint>();
			this.InstantaniousCadenceDataPoints = new List<CustomDatapoint>();
			this.AccumulatedPowerDataPoints = new List<CustomDatapoint>();
			this.InstantaniousPowerDataPoints = new List<CustomDatapoint>();
			this.EventCountDatapoints = new List<double>();

			this.HeartrateChartsListeningForUpdates = new ConcurrentBag<Chart>();
			this.SpeedChartsListeningForUpdates = new ConcurrentBag<Chart>();
			this.DistanceChartsListeningForUpdates = new ConcurrentBag<Chart>();
			this.InstantaniousCadenceChartsListeningForUpdates = new ConcurrentBag<Chart>();
			this.AccumulatedPowerChartsListeningForUpdates = new ConcurrentBag<Chart>();
			this.InstantaniousPowerChartsListeningForUpdates = new ConcurrentBag<Chart>();
		}

		private void AddData(string timestamp, string data, List<CustomDatapoint> list)
		{
			if (data != null)
			{
				list.Add(new CustomDatapoint(DateTime.Parse(timestamp), double.Parse(data)));
			}
		}

		private void AddSpeedData(string timestamp, double data, List<CustomDatapoint> list)
		{
			list.Add(new CustomDatapoint(DateTime.Parse(timestamp), data));
		}

		public void AddHeartrateDataPoint(string timestamp, string data)
		{
			this.AddData(timestamp, data, this.HeartrateDataPoints);
			foreach (Chart chart in this.HeartrateChartsListeningForUpdates)
			{
				ChartUtils.updateChart(chart, this.HeartrateDataPoints);
			}
			if (this.MainChartListening == true && this.MainChartListeningToData == DataTag.HR.ToString() && this.MainChart != null)
			{
				ChartUtils.updateChart(this.MainChart, this.HeartrateDataPoints);
			}

		}

		public void AddSpeedDataPoint(string timestamp, string data)
		{
			if (data != null)
			{
				// addSpeedData(timestamp, Double.Parse(data) * 3.6 , this.SpeedDataPoints);
				this.AddSpeedData(timestamp, double.Parse(data), this.SpeedDataPoints);
			}

			foreach (Chart chart in this.SpeedChartsListeningForUpdates)
			{
				ChartUtils.updateChart(chart, this.SpeedDataPoints);
			}
			if (this.MainChartListening == true && this.MainChartListeningToData == DataTag.SP.ToString() && this.MainChart != null)
			{
				ChartUtils.updateChart(this.MainChart, this.SpeedDataPoints);
			}
		}

		public void AddDistanceDataPoint(string timestamp, string data)
		{
			this.AddData(timestamp, data, this.DistanceDataPoints);
			foreach (Chart chart in this.DistanceChartsListeningForUpdates)
			{
				ChartUtils.updateChart(chart, this.DistanceDataPoints);
			}


		}

		public void AddInstantaniousCadenceDataPoint(string timestamp, string data)
		{
			this.AddData(timestamp, data, this.InstantaniousCadenceDataPoints);
			foreach (Chart chart in this.InstantaniousCadenceChartsListeningForUpdates)
			{
				ChartUtils.updateChart(chart, this.InstantaniousCadenceDataPoints);
			}
			if (this.MainChartListening == true && this.MainChartListeningToData == DataTag.IC.ToString() && this.MainChart != null)
			{
				ChartUtils.updateChart(this.MainChart, this.InstantaniousCadenceDataPoints);
			}
		}

		public void AddAccumulatedPowerDataPoint(string timestamp, string data)
		{
			this.AddData(timestamp, data, this.AccumulatedPowerDataPoints);
			foreach (Chart chart in this.AccumulatedPowerChartsListeningForUpdates)
			{
				ChartUtils.updateChart(chart, this.AccumulatedPowerDataPoints);
			}
			if (this.MainChartListening == true && this.MainChartListeningToData == DataTag.AP.ToString() && this.MainChart != null)
			{
				ChartUtils.updateChart(this.MainChart, this.AccumulatedPowerDataPoints);
			}
		}

		public void AddInstantaniousPowerDataPoint(string timestamp, string data)
		{
			this.AddData(timestamp, data, this.InstantaniousPowerDataPoints);
			foreach (Chart chart in this.InstantaniousPowerChartsListeningForUpdates)
			{
				ChartUtils.updateChart(chart, this.InstantaniousPowerDataPoints);
			}
			if (this.MainChartListening == true && this.MainChartListeningToData == DataTag.IP.ToString() && this.MainChart != null)
			{
				ChartUtils.updateChart(this.MainChart, this.InstantaniousPowerDataPoints);
			}
		}

		public void AddEventCountDataPoint(string timestamp, string data)
		{
			this.EventCountDatapoints.Add(double.Parse(data));
		}

		public bool PatientHasDataAlready(string eventCount)
		{
			return this.EventCountDatapoints.Contains(double.Parse(eventCount));
		}

		private void AddListeningChart(Chart chart, ConcurrentBag<Chart> charts)
		{
			charts.Add(chart);
		}

		public void AddListeningHeartrateChart(Chart chart)
		{
			this.AddListeningChart(chart, this.HeartrateChartsListeningForUpdates);
		}

		public void AddListeningSpeedChart(Chart chart)
		{
			this.AddListeningChart(chart, this.SpeedChartsListeningForUpdates);
		}

		public void AddListeningDistanceChart(Chart chart)
		{
			this.AddListeningChart(chart, this.DistanceChartsListeningForUpdates);
		}

		public void AddListeningInstantaniousCadenceChart(Chart chart)
		{
			this.AddListeningChart(chart, this.InstantaniousCadenceChartsListeningForUpdates);
		}

		public void AddListeningAccumulatedPowerChart(Chart chart)
		{
			this.AddListeningChart(chart, this.AccumulatedPowerChartsListeningForUpdates);
		}

		public void AddListeningInstantaniousPowerChart(Chart chart)
		{
			this.AddListeningChart(chart, this.InstantaniousPowerChartsListeningForUpdates);
		}

		public void SetListeningData(DataTag tag)
		{
			switch (tag)
			{
				case DataTag.HR:
					this.MainChartListeningToData = DataTag.HR.ToString();
					break;
				case DataTag.SP:
					this.MainChartListeningToData = DataTag.SP.ToString();
					break;
				case DataTag.IC:
					this.MainChartListeningToData = DataTag.IC.ToString();
					break;
				case DataTag.AP:
					this.MainChartListeningToData = DataTag.AP.ToString();
					break;
				case DataTag.IP:
					this.MainChartListeningToData = DataTag.IP.ToString();
					break;
			}
		}
	}
}
