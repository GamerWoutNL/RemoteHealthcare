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

namespace DoktorApp
{
    public partial class SmallPatientView : UserControl
    {

        public string patientName { get; set; }
        public string patientNumber { get; set; }
        public int resistance { get; set; }
        internal List<CustomDatapoint> HeartrateDatapoints { get => heartrateDatapoints; set => heartrateDatapoints = value; }

        private List<CustomDatapoint> heartrateDatapoints = new List<CustomDatapoint>();
        
        internal List<CustomDatapoint> SpeedDataPoints { get => speedDataPoints; set => speedDataPoints = value; }

        private List<CustomDatapoint> speedDataPoints = new List<CustomDatapoint>();

        public SmallPatientView()
        {
            InitializeComponent();
        }

        public SmallPatientView(string PatientName, string PatientNumber)
        {
            InitializeComponent();
            this.PatientNameLabel.Text = $"Patient naam: {PatientName}";
            this.PatientNumberLabel.Text = $"Patient nummer: {PatientNumber}";
            
            this.HeartrateChart.Series.Clear();

            AddHeartrateDataPoint(new CustomDatapoint(new DateTime(2017, 05, 17, 12, 12, 12), 89.0));
            AddHeartrateDataPoint(new CustomDatapoint(DateTime.Now, 78.0));
            
            
            
            
        }

        private void PatientNameLabel_Click(object sender, EventArgs e)
        {
            DetailedPatientView patientView = new DetailedPatientView();
            patientView.Show();
        }

        private void AddHeartrateDataPoint(CustomDatapoint hrPoint)
        {

            ChartUtils.addDatapointToListForChart(hrPoint, this.heartrateDatapoints, this.HeartrateChart);
            /*
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
            */
        }

        private void AddSpeedDataPoint(CustomDatapoint speedDataPoint)
        {

            ChartUtils.addDatapointToListForChart(speedDataPoint, this.SpeedDataPoints, this.SpeedChart);


            /*
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
            */
        }

    }
}
