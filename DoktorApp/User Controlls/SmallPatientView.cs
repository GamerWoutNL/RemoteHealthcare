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
        internal PatientStorage Storage { get => storage; set => storage = value; }

        private PatientStorage storage;
        

        public SmallPatientView(string PatientName, string PatientNumber, Client client, PatientStorage storage)
        {
			this.client = client;
            this.Storage = storage;
            InitializeComponent();
            this.PatientNameLabel.Text = $"Patient naam: {PatientName}";
            this.PatientNumberLabel.Text = $"Patient nummer: {PatientNumber}";
            
            this.HeartrateChart.Series.Clear();

            storage.AddListeningHeartrateChart(this.HeartrateChart);
            storage.AddListeningSpeedChart(this.SpeedChart);
        }

        private void PatientNameLabel_Click(object sender, EventArgs e)
        {
            DetailedPatientView patientView = new DetailedPatientView(this.patientName, this.patientNumber, this.client, this.storage);
            patientView.Show();
        }

        private void AddHeartrateDataPoint(CustomDatapoint hrPoint)
        {
            ChartUtils.addDatapointToListForChart(hrPoint, this.storage.HeartrateDataPoints, this.HeartrateChart);
        }

        private void AddSpeedDataPoint(CustomDatapoint speedDataPoint)
        {
            ChartUtils.addDatapointToListForChart(speedDataPoint, this.storage.SpeedDataPoints, this.SpeedChart);
        }

    }
}
