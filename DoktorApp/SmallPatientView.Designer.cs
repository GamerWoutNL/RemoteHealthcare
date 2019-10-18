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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PatientNameLabel = new System.Windows.Forms.Label();
            this.PatientNumberLabel = new System.Windows.Forms.Label();
            this.HeartrateChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SpeedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ResistanceLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HeartrateChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedChart)).BeginInit();
            this.SuspendLayout();
            // 
            // PatientNameLabel
            // 
            this.PatientNameLabel.AutoSize = true;
            this.PatientNameLabel.Location = new System.Drawing.Point(17, 30);
            this.PatientNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PatientNameLabel.Name = "PatientNameLabel";
            this.PatientNameLabel.Size = new System.Drawing.Size(101, 17);
            this.PatientNameLabel.TabIndex = 0;
            this.PatientNameLabel.Text = "Patient Name: ";
            this.PatientNameLabel.Click += new System.EventHandler(this.PatientNameLabel_Click);
            // 
            // PatientNumberLabel
            // 
            this.PatientNumberLabel.AutoSize = true;
            this.PatientNumberLabel.Location = new System.Drawing.Point(17, 60);
            this.PatientNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PatientNumberLabel.Name = "PatientNumberLabel";
            this.PatientNumberLabel.Size = new System.Drawing.Size(114, 17);
            this.PatientNumberLabel.TabIndex = 1;
            this.PatientNumberLabel.Text = "Patient Number: ";
            // 
            // HeartrateChart
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.HeartrateChart.ChartAreas.Add(chartArea1);
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.IsDockedInsideChartArea = false;
            legend1.Name = "Legend1";
            this.HeartrateChart.Legends.Add(legend1);
            this.HeartrateChart.Location = new System.Drawing.Point(21, 92);
            this.HeartrateChart.Margin = new System.Windows.Forms.Padding(4);
            this.HeartrateChart.Name = "HeartrateChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.HeartrateChart.Series.Add(series1);
            this.HeartrateChart.Size = new System.Drawing.Size(267, 246);
            this.HeartrateChart.TabIndex = 2;
            this.HeartrateChart.Text = "chart1";
            // 
            // SpeedChart
            // 
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.Name = "ChartArea1";
            this.SpeedChart.ChartAreas.Add(chartArea2);
            legend2.DockedToChartArea = "ChartArea1";
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.IsDockedInsideChartArea = false;
            legend2.Name = "Legend1";
            this.SpeedChart.Legends.Add(legend2);
            this.SpeedChart.Location = new System.Drawing.Point(21, 366);
            this.SpeedChart.Margin = new System.Windows.Forms.Padding(4);
            this.SpeedChart.Name = "SpeedChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.SpeedChart.Series.Add(series2);
            this.SpeedChart.Size = new System.Drawing.Size(267, 246);
            this.SpeedChart.TabIndex = 3;
            this.SpeedChart.Text = "chart1";
            // 
            // ResistanceLabel
            // 
            this.ResistanceLabel.AutoSize = true;
            this.ResistanceLabel.Location = new System.Drawing.Point(17, 636);
            this.ResistanceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ResistanceLabel.Name = "ResistanceLabel";
            this.ResistanceLabel.Size = new System.Drawing.Size(98, 17);
            this.ResistanceLabel.TabIndex = 4;
            this.ResistanceLabel.Text = "Resistance: %";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "See Details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SmallPatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ResistanceLabel);
            this.Controls.Add(this.SpeedChart);
            this.Controls.Add(this.HeartrateChart);
            this.Controls.Add(this.PatientNumberLabel);
            this.Controls.Add(this.PatientNameLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SmallPatientView";
            this.Size = new System.Drawing.Size(319, 673);
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
    }
}
