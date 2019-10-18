using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DoktorApp.Communication;
using DoktorApp.Data_Management;

namespace DoktorApp
{
    public partial class SmallPatientView : UserControl
    {
		private Client client;

        
        public string patientName { get; set; }
        public string patientNumber { get; set; }
        public int resistance { get; set; }
        public string doctorID;
        internal List<CustomDatapoint> HeartrateDatapoints { get => heartrateDatapoints; set => heartrateDatapoints = value; }

        private List<CustomDatapoint> heartrateDatapoints = new List<CustomDatapoint>();
        
        internal List<CustomDatapoint> SpeedDataPoints { get => speedDataPoints; set => speedDataPoints = value; }
        internal PatientStorage Storage { get => storage; set => storage = value; }

        private PatientStorage storage;
        private List<CustomDatapoint> speedDataPoints = new List<CustomDatapoint>();

        public SmallPatientView(string PatientName, string PatientNumber, Client client, PatientStorage storage)
        {
			this.client = client;
            this.Storage = storage;
            InitializeComponent();
            this.PatientNameLabel.Text = $"Patient naam: {PatientName}";
            this.PatientNumberLabel.Text = $"Patient nummer: {PatientNumber}";
            this.doctorID = doctorID;

            this.patientName = PatientName;
            this.patientNumber = PatientNumber;
            
            this.HeartrateChart.Series.Clear();

           // AddHeartrateDataPoint(new HeartrateDatapoint(new DateTime(2017, 05, 17, 12, 12, 12), 89));
            //AddHeartrateDataPoint(new HeartrateDatapoint(DateTime.Now, 78));
            
            
            
            
        }

        private void PatientNameLabel_Click(object sender, EventArgs e)
        {
            DetailedPatientView patientView = new DetailedPatientView(patientName, patientNumber, client, storage);
            patientView.Show();
        }

        private void AddHeartrateDataPoint(CustomDatapoint hrPoint)
        {
            this.heartrateDatapoints.Add(hrPoint);
            //this.heartrateDatapoints.OrderByDescending(heartrateDatapoint => heartrateDatapoint.timestamp);
            this.heartrateDatapoints.Sort((x, y) => y.timestamp.CompareTo(x.timestamp));

            this.HeartrateChart.Series.Clear();

            Series heartrateSeries = new Series();
            heartrateSeries.ChartType = SeriesChartType.Line;
            heartrateSeries.Name = "Heartrate";
            
            int counter = 1;
            foreach(CustomDatapoint hrPoint1 in HeartrateDatapoints)
            {
                
                heartrateSeries.Points.Add(new DataPoint(counter, hrPoint1.data));
                counter++;
            }

            this.HeartrateChart.Series.Add(heartrateSeries);
        }

        private void AddSpeedDataPoint(CustomDatapoint speedDataPoint)
        {
            this.speedDataPoints.Add(speedDataPoint);
            this.speedDataPoints.Sort((x, y) => y.timestamp.CompareTo(x.timestamp));

            this.SpeedChart.Series.Clear();

            Series speedSeries = new Series();
            speedSeries.ChartType = SeriesChartType.Line;
            speedSeries.Name = "Speed";

            int counter = 1;
            foreach(CustomDatapoint spPoint1 in SpeedDataPoints)
            {
                speedSeries.Points.Add(new DataPoint(counter, spPoint1.data));
                counter++;
            }

            this.SpeedChart.Series.Add(speedSeries);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DetailedPatientView patientView = new DetailedPatientView(patientName, patientNumber, client, storage);
            patientView.Show();
        }
    }
}
