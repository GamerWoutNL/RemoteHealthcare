namespace DoktorApp
{
    partial class SmallPatientView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PatientNameLabel = new System.Windows.Forms.Label();
            this.PatientNumberLabel = new System.Windows.Forms.Label();
            this.HeartrateChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SpeedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ResistanceLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.bgHrChart = new System.ComponentModel.BackgroundWorker();
            this.bgSpeedChart = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.HeartrateChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedChart)).BeginInit();
            this.SuspendLayout();
            // 
            // PatientNameLabel
            // 
            this.PatientNameLabel.AutoSize = true;
            this.PatientNameLabel.Location = new System.Drawing.Point(13, 24);
            this.PatientNameLabel.Name = "PatientNameLabel";
            this.PatientNameLabel.Size = new System.Drawing.Size(88, 15);
            this.PatientNameLabel.TabIndex = 0;
            this.PatientNameLabel.Text = "Patient Name: ";
            this.PatientNameLabel.Click += new System.EventHandler(this.PatientNameLabel_Click);
            // 
            // PatientNumberLabel
            // 
            this.PatientNumberLabel.AutoSize = true;
            this.PatientNumberLabel.Location = new System.Drawing.Point(13, 49);
            this.PatientNumberLabel.Name = "PatientNumberLabel";
            this.PatientNumberLabel.Size = new System.Drawing.Size(99, 15);
            this.PatientNumberLabel.TabIndex = 1;
            this.PatientNumberLabel.Text = "Patient Number: ";
            // 
            // HeartrateChart
            // 
            chartArea13.AxisX.MajorGrid.Enabled = false;
            chartArea13.AxisY.MajorGrid.Enabled = false;
            chartArea13.Name = "ChartArea1";
            this.HeartrateChart.ChartAreas.Add(chartArea13);
            legend13.DockedToChartArea = "ChartArea1";
            legend13.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend13.IsDockedInsideChartArea = false;
            legend13.Name = "Legend1";
            this.HeartrateChart.Legends.Add(legend13);
            this.HeartrateChart.Location = new System.Drawing.Point(16, 75);
            this.HeartrateChart.Name = "HeartrateChart";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            this.HeartrateChart.Series.Add(series13);
            this.HeartrateChart.Size = new System.Drawing.Size(200, 200);
            this.HeartrateChart.TabIndex = 2;
            this.HeartrateChart.Text = "chart1";
            // 
            // SpeedChart
            // 
            chartArea14.AxisX.MajorGrid.Enabled = false;
            chartArea14.AxisY.MajorGrid.Enabled = false;
            chartArea14.Name = "ChartArea1";
            this.SpeedChart.ChartAreas.Add(chartArea14);
            legend14.DockedToChartArea = "ChartArea1";
            legend14.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend14.IsDockedInsideChartArea = false;
            legend14.Name = "Legend1";
            this.SpeedChart.Legends.Add(legend14);
            this.SpeedChart.Location = new System.Drawing.Point(16, 297);
            this.SpeedChart.Name = "SpeedChart";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.Legend = "Legend1";
            series14.Name = "Series1";
            this.SpeedChart.Series.Add(series14);
            this.SpeedChart.Size = new System.Drawing.Size(200, 200);
            this.SpeedChart.TabIndex = 3;
            this.SpeedChart.Text = "chart1";
            // 
            // ResistanceLabel
            // 
            this.ResistanceLabel.AutoSize = true;
            this.ResistanceLabel.Location = new System.Drawing.Point(13, 517);
            this.ResistanceLabel.Name = "ResistanceLabel";
            this.ResistanceLabel.Size = new System.Drawing.Size(85, 15);
            this.ResistanceLabel.TabIndex = 4;
            this.ResistanceLabel.Text = "Resistance: %";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "See Details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bgHrChart
            // 
            this.bgHrChart.WorkerReportsProgress = true;
            this.bgHrChart.WorkerSupportsCancellation = true;
            this.bgHrChart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgHrChart_DoWork);
            this.bgHrChart.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgHrChart_ProgressChanged);
            this.bgHrChart.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgHrChart_RunWorkerCompleted);
            // 
            // bgSpeedChart
            // 
            this.bgSpeedChart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSpeedChart_DoWork);
            this.bgSpeedChart.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgSpeedChart_ProgressChanged);
            this.bgSpeedChart.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgSpeedChart_RunWorkerCompleted);
            // 
            // SmallPatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ResistanceLabel);
            this.Controls.Add(this.SpeedChart);
            this.Controls.Add(this.HeartrateChart);
            this.Controls.Add(this.PatientNumberLabel);
            this.Controls.Add(this.PatientNameLabel);
            this.Name = "SmallPatientView";
            this.Size = new System.Drawing.Size(239, 547);
            ((System.ComponentModel.ISupportInitialize)(this.HeartrateChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PatientNameLabel;
        private System.Windows.Forms.Label PatientNumberLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart HeartrateChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart SpeedChart;
        private System.Windows.Forms.Label ResistanceLabel;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker bgHrChart;
        private System.ComponentModel.BackgroundWorker bgSpeedChart;
    }
}
