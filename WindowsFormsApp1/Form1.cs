using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.ListViewItem;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(new UserControl1());
        }

        private FlowLayoutPanel CreatePatientPanel(string name, string patientNumber, int[] heartrateData, double[] speedData, int resistance)
        {

            FlowLayoutPanel flowPanel1 = new FlowLayoutPanel();
            flowPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            flowPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowPanel1.Location = new System.Drawing.Point(13, 13);
            flowPanel1.Name = "PatientPanel1";
            flowPanel1.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            flowPanel1.Size = new System.Drawing.Size(225, 378);
            flowPanel1.TabIndex = 0;

            Label nameLabel1 = new Label();
            nameLabel1.Text = name;
            nameLabel1.AutoSize = true;
            nameLabel1.Location = new System.Drawing.Point(13, 10);
            nameLabel1.Size = new System.Drawing.Size(82, 15);
            nameLabel1.TabIndex = 0;


            Label numberLabel1 = new Label();
            numberLabel1.Text = patientNumber;
            numberLabel1.AutoSize = true;
            numberLabel1.Location = new System.Drawing.Point(13, 25);
            numberLabel1.Size = new System.Drawing.Size(93, 15);
            numberLabel1.TabIndex = 0;

            Chart heartrateChart1 = new Chart();
            Chart speedChart1 = new Chart();

            ChartArea ca1 = new ChartArea();
            ca1.Name = "ca1";
            ca1.AxisX.MajorGrid.Enabled = false;
            ca1.AxisY.MajorGrid.Enabled = false;

            ChartArea ca2 = new ChartArea();
            ca2.Name = "ca2";
            ca2.AxisX.MajorGrid.Enabled = false;
            ca2.AxisY.MajorGrid.Enabled = false;

            Legend legend1 = new Legend();
            legend1.Name = "Legend1";
            legend1.DockedToChartArea = "ca1";
            legend1.Docking = Docking.Top;
            legend1.IsDockedInsideChartArea = false;
            legend1.IsTextAutoFit = false;
            legend1.TextWrapThreshold = 10;

            Legend legend2 = new Legend();
            legend2.Name = "Legend2";
            legend2.DockedToChartArea = "ca2";
            legend2.Docking = Docking.Top;
            legend2.IsDockedInsideChartArea = false;
            legend2.IsTextAutoFit = false;
            legend2.TextWrapThreshold = 10;

            Series HrSeries = new Series();
            HrSeries.ChartArea = "ca1";
            HrSeries.ChartType = SeriesChartType.Line;
            HrSeries.Legend = "Legend1";
            HrSeries.Name = "HrSeries";

            Series SpeedSeries = new Series();
            SpeedSeries.ChartArea = "ca2";
            SpeedSeries.ChartType = SeriesChartType.Line;
            SpeedSeries.Legend = "Legend2";
            SpeedSeries.Name = "SpeedSeries";

            Label resistanceLabel1 = new Label();
            resistanceLabel1.Text = $"Resistance ={resistance}%";
            resistanceLabel1.AutoSize = true;
            resistanceLabel1.Location = new Point(13, 352);
            resistanceLabel1.Size = new Size(82, 15);
            resistanceLabel1.TabIndex = 4;

            heartrateChart1.Series.Add(HrSeries);
            heartrateChart1.Legends.Add(legend1);
            heartrateChart1.ChartAreas.Add(ca1);
            
            speedChart1.Series.Add(SpeedSeries);
            speedChart1.Legends.Add(legend2);
            speedChart1.ChartAreas.Add(ca2);

            flowPanel1.Controls.Add(nameLabel1);
            flowPanel1.Controls.Add(numberLabel1);
            flowPanel1.Controls.Add(heartrateChart1);
            flowPanel1.Controls.Add(speedChart1);
            flowPanel1.Controls.Add(resistanceLabel1);


            return new FlowLayoutPanel();
        }
    }
}
