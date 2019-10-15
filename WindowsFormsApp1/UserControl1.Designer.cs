namespace WindowsFormsApp1
{
    partial class UserControl1
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
            this.heartrateChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.speedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ResistanceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.heartrateChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).BeginInit();
            this.SuspendLayout();
            // 
            // PatientNameLabel
            // 
            this.PatientNameLabel.AutoSize = true;
            this.PatientNameLabel.Location = new System.Drawing.Point(6, 9);
            this.PatientNameLabel.Name = "PatientNameLabel";
            this.PatientNameLabel.Size = new System.Drawing.Size(82, 15);
            this.PatientNameLabel.TabIndex = 0;
            this.PatientNameLabel.Text = "Patient Name";
            // 
            // PatientNumberLabel
            // 
            this.PatientNumberLabel.AutoSize = true;
            this.PatientNumberLabel.Location = new System.Drawing.Point(6, 24);
            this.PatientNumberLabel.Name = "PatientNumberLabel";
            this.PatientNumberLabel.Size = new System.Drawing.Size(93, 15);
            this.PatientNumberLabel.TabIndex = 1;
            this.PatientNumberLabel.Text = "Patient Number";
            // 
            // heartrateChart
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.heartrateChart.ChartAreas.Add(chartArea1);
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.IsDockedInsideChartArea = false;
            legend1.Name = "Legend1";
            this.heartrateChart.Legends.Add(legend1);
            this.heartrateChart.Location = new System.Drawing.Point(9, 42);
            this.heartrateChart.Name = "heartrateChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.heartrateChart.Series.Add(series1);
            this.heartrateChart.Size = new System.Drawing.Size(200, 175);
            this.heartrateChart.TabIndex = 2;
            this.heartrateChart.Text = "hrChart";
            // 
            // speedChart
            // 
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.Name = "ChartArea1";
            this.speedChart.ChartAreas.Add(chartArea2);
            legend2.DockedToChartArea = "ChartArea1";
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.IsDockedInsideChartArea = false;
            legend2.Name = "Legend1";
            this.speedChart.Legends.Add(legend2);
            this.speedChart.Location = new System.Drawing.Point(9, 225);
            this.speedChart.Name = "speedChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.speedChart.Series.Add(series2);
            this.speedChart.Size = new System.Drawing.Size(200, 175);
            this.speedChart.TabIndex = 3;
            this.speedChart.Text = "speedChart";
            // 
            // ResistanceLabel
            // 
            this.ResistanceLabel.AutoSize = true;
            this.ResistanceLabel.Location = new System.Drawing.Point(26, 412);
            this.ResistanceLabel.Name = "ResistanceLabel";
            this.ResistanceLabel.Size = new System.Drawing.Size(82, 15);
            this.ResistanceLabel.TabIndex = 4;
            this.ResistanceLabel.Text = "Resistance %";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ResistanceLabel);
            this.Controls.Add(this.speedChart);
            this.Controls.Add(this.heartrateChart);
            this.Controls.Add(this.PatientNumberLabel);
            this.Controls.Add(this.PatientNameLabel);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(246, 463);
            ((System.ComponentModel.ISupportInitialize)(this.heartrateChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PatientNameLabel;
        private System.Windows.Forms.Label PatientNumberLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart heartrateChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart speedChart;
        private System.Windows.Forms.Label ResistanceLabel;
    }
}
