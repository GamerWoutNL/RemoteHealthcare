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
        internal List<HeartrateDatapoint> HeartrateDatapoints { get => heartrateDatapoints; set => heartrateDatapoints = value; }

        private List<HeartrateDatapoint> heartrateDatapoints = new List<HeartrateDatapoint>();
        

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

            AddHeartrateDataPoint(new HeartrateDatapoint(DateTime.Now, 78));
            AddHeartrateDataPoint(new HeartrateDatapoint(new DateTime(2017, 05, 17, 12, 12, 12), 89));
            
            
            
        }

        private void PatientNameLabel_Click(object sender, EventArgs e)
        {
            DetailedPatientView patientView = new DetailedPatientView();
            patientView.Show();
        }

        private void AddHeartrateDataPoint(HeartrateDatapoint hrPoint)
        {
            this.heartrateDatapoints.Add(hrPoint);
            this.heartrateDatapoints.OrderByDescending(heartrateDatapoint => heartrateDatapoint.timestamp);

            this.HeartrateChart.Series.Clear();

            Series heartrateSeries = new Series();
            heartrateSeries.ChartType = SeriesChartType.Line;
            heartrateSeries.Name = "Heartrate";
            
            int counter = 1;
            foreach(HeartrateDatapoint hrPoint1 in HeartrateDatapoints)
            {
                
                heartrateSeries.Points.Add(new DataPoint(counter, hrPoint1.heartrateData));
                counter++;
            }

            this.HeartrateChart.Series.Add(heartrateSeries);
        }

        

    }
}
