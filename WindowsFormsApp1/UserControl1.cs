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

namespace WindowsFormsApp1
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public UserControl1(string PatientName, string PatientNumber, int[] HeartrateData, double[] SpeedData, int resistancePercentage)
        {
            InitializeComponent();
            this.PatientNameLabel.Text = $"Patient name = {PatientName}";
            this.PatientNumberLabel.Text = $"Patient number = {PatientNumber}";
            this.ResistanceLabel.Text = $"Resistance = {resistancePercentage}%";

            Series heartrateSeries = new Series();

            DataPoint test = new DataPoint()            
        }

    }
}
