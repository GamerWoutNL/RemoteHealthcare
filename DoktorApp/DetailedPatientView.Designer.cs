namespace DoktorApp
{
    partial class DetailedPatientView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailedPatientView));
            this.chart_mainchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_file = new System.Windows.Forms.Button();
            this.textbox_message = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.HeartrateChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SpeedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.InstCadenceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.AccPowerChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.InstPowerChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_sendmessage = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.label_patientname = new System.Windows.Forms.Label();
            this.label_patientnumber = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_mainchart)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeartrateChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstCadenceChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccPowerChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstPowerChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_mainchart
            // 
            this.chart_mainchart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chart_mainchart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            chartArea1.Name = "ChartArea1";
            this.chart_mainchart.ChartAreas.Add(chartArea1);
            this.chart_mainchart.Location = new System.Drawing.Point(285, 143);
            this.chart_mainchart.Margin = new System.Windows.Forms.Padding(2);
            this.chart_mainchart.Name = "chart_mainchart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chart_mainchart.Series.Add(series1);
            this.chart_mainchart.Size = new System.Drawing.Size(613, 390);
            this.chart_mainchart.TabIndex = 7;
            this.chart_mainchart.Text = "chart1";
            // 
            // button_file
            // 
            this.button_file.Location = new System.Drawing.Point(824, 567);
            this.button_file.Margin = new System.Windows.Forms.Padding(2);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(74, 21);
            this.button_file.TabIndex = 8;
            this.button_file.Text = "Open File";
            this.button_file.UseVisualStyleBackColor = true;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // textbox_message
            // 
            this.textbox_message.Location = new System.Drawing.Point(285, 105);
            this.textbox_message.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_message.Name = "textbox_message";
            this.textbox_message.Size = new System.Drawing.Size(153, 20);
            this.textbox_message.TabIndex = 9;
            this.textbox_message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_message_KeyDown);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.flowLayoutPanel1.Controls.Add(this.HeartrateChart);
            this.flowLayoutPanel1.Controls.Add(this.SpeedChart);
            this.flowLayoutPanel1.Controls.Add(this.InstCadenceChart);
            this.flowLayoutPanel1.Controls.Add(this.AccPowerChart);
            this.flowLayoutPanel1.Controls.Add(this.InstPowerChart);
            this.flowLayoutPanel1.DataBindings.Add(new System.Windows.Forms.Binding("FlowDirection", global::DoktorApp.Properties.Settings.Default, "flowtopdown", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel1.FlowDirection = global::DoktorApp.Properties.Settings.Default.flowtopdown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 24);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(225, 569);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(225, 530);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // HeartrateChart
            // 
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX2.LabelStyle.Enabled = false;
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY2.LabelStyle.Enabled = false;
            chartArea2.Name = "ChartArea1";
            this.HeartrateChart.ChartAreas.Add(chartArea2);
            this.HeartrateChart.Location = new System.Drawing.Point(3, 3);
            this.HeartrateChart.Name = "HeartrateChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsXValueIndexed = true;
            series2.Name = "Series1";
            this.HeartrateChart.Series.Add(series2);
            this.HeartrateChart.Size = new System.Drawing.Size(222, 99);
            this.HeartrateChart.TabIndex = 0;
            this.HeartrateChart.Text = "chart1";
            title1.Alignment = System.Drawing.ContentAlignment.TopRight;
            title1.Name = "Title1";
            title1.Text = "Heartrate";
            this.HeartrateChart.Titles.Add(title1);
            this.HeartrateChart.Click += new System.EventHandler(this.HeartrateChartClick);
            // 
            // SpeedChart
            // 
            chartArea3.AxisX.LabelStyle.Enabled = false;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX2.LabelStyle.Enabled = false;
            chartArea3.AxisY.LabelStyle.Enabled = false;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea3.AxisY2.LabelStyle.Enabled = false;
            chartArea3.Name = "ChartArea1";
            this.SpeedChart.ChartAreas.Add(chartArea3);
            this.SpeedChart.Location = new System.Drawing.Point(3, 108);
            this.SpeedChart.Name = "SpeedChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.IsXValueIndexed = true;
            series3.Name = "Series1";
            this.SpeedChart.Series.Add(series3);
            this.SpeedChart.Size = new System.Drawing.Size(222, 99);
            this.SpeedChart.TabIndex = 1;
            this.SpeedChart.Text = "chart2";
            title2.Alignment = System.Drawing.ContentAlignment.TopRight;
            title2.Name = "Title1";
            title2.Text = "Speed";
            this.SpeedChart.Titles.Add(title2);
            this.SpeedChart.Click += new System.EventHandler(this.SpeedChartClick);
            // 
            // InstCadenceChart
            // 
            chartArea4.AxisX.LabelStyle.Enabled = false;
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea4.AxisX2.LabelStyle.Enabled = false;
            chartArea4.AxisY.LabelStyle.Enabled = false;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea4.AxisY2.LabelStyle.Enabled = false;
            chartArea4.Name = "ChartArea1";
            this.InstCadenceChart.ChartAreas.Add(chartArea4);
            this.InstCadenceChart.Location = new System.Drawing.Point(3, 213);
            this.InstCadenceChart.Name = "InstCadenceChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Name = "Series1";
            this.InstCadenceChart.Series.Add(series4);
            this.InstCadenceChart.Size = new System.Drawing.Size(222, 99);
            this.InstCadenceChart.TabIndex = 2;
            this.InstCadenceChart.Text = "chart3";
            title3.Alignment = System.Drawing.ContentAlignment.TopRight;
            title3.Name = "Title1";
            title3.Text = "Instant Cadence";
            this.InstCadenceChart.Titles.Add(title3);
            this.InstCadenceChart.Click += new System.EventHandler(this.InstantCadenceChartClick);
            // 
            // AccPowerChart
            // 
            chartArea5.AxisX.LabelStyle.Enabled = false;
            chartArea5.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisX2.LabelStyle.Enabled = false;
            chartArea5.AxisY.LabelStyle.Enabled = false;
            chartArea5.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea5.AxisY2.LabelStyle.Enabled = false;
            chartArea5.Name = "ChartArea1";
            this.AccPowerChart.ChartAreas.Add(chartArea5);
            this.AccPowerChart.Location = new System.Drawing.Point(3, 318);
            this.AccPowerChart.Name = "AccPowerChart";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Name = "Series1";
            this.AccPowerChart.Series.Add(series5);
            this.AccPowerChart.Size = new System.Drawing.Size(222, 99);
            this.AccPowerChart.TabIndex = 3;
            this.AccPowerChart.Text = "chart4";
            title4.Alignment = System.Drawing.ContentAlignment.TopRight;
            title4.Name = "Title1";
            title4.Text = "Accumulated Power";
            this.AccPowerChart.Titles.Add(title4);
            this.AccPowerChart.Click += new System.EventHandler(this.AccumulatedPowerChartClick);
            // 
            // InstPowerChart
            // 
            chartArea6.AxisX.LabelStyle.Enabled = false;
            chartArea6.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea6.AxisX2.LabelStyle.Enabled = false;
            chartArea6.AxisY.LabelStyle.Enabled = false;
            chartArea6.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea6.AxisY2.LabelStyle.Enabled = false;
            chartArea6.Name = "ChartArea1";
            this.InstPowerChart.ChartAreas.Add(chartArea6);
            this.InstPowerChart.Location = new System.Drawing.Point(3, 423);
            this.InstPowerChart.Name = "InstPowerChart";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Name = "Series1";
            this.InstPowerChart.Series.Add(series6);
            this.InstPowerChart.Size = new System.Drawing.Size(222, 99);
            this.InstPowerChart.TabIndex = 4;
            this.InstPowerChart.Text = "chart5";
            title5.Alignment = System.Drawing.ContentAlignment.TopRight;
            title5.Name = "Title1";
            title5.Text = "Instant Power";
            this.InstPowerChart.Titles.Add(title5);
            this.InstPowerChart.Click += new System.EventHandler(this.InstantPowerChartClick);
            // 
            // button_sendmessage
            // 
            this.button_sendmessage.Location = new System.Drawing.Point(442, 103);
            this.button_sendmessage.Margin = new System.Windows.Forms.Padding(2);
            this.button_sendmessage.Name = "button_sendmessage";
            this.button_sendmessage.Size = new System.Drawing.Size(56, 21);
            this.button_sendmessage.TabIndex = 11;
            this.button_sendmessage.Text = "Send";
            this.button_sendmessage.UseVisualStyleBackColor = true;
            this.button_sendmessage.Click += new System.EventHandler(this.button_sendbutton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(512, 56);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // label_patientname
            // 
            this.label_patientname.AutoSize = true;
            this.label_patientname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label_patientname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label_patientname.Location = new System.Drawing.Point(281, 53);
            this.label_patientname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_patientname.Name = "label_patientname";
            this.label_patientname.Size = new System.Drawing.Size(224, 24);
            this.label_patientname.TabIndex = 18;
            this.label_patientname.Text = "ReplaceWithPatientName";
            // 
            // label_patientnumber
            // 
            this.label_patientnumber.AutoSize = true;
            this.label_patientnumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label_patientnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_patientnumber.Location = new System.Drawing.Point(280, 80);
            this.label_patientnumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_patientnumber.Name = "label_patientnumber";
            this.label_patientnumber.Size = new System.Drawing.Size(145, 17);
            this.label_patientnumber.TabIndex = 19;
            this.label_patientnumber.Text = "ReplaceWithPatientID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(415, 76);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 26);
            this.button1.TabIndex = 20;
            this.button1.Text = "End Session";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_endsession_click);
            // 
            // DetailedPatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DoktorApp.Properties.Resources.Hospital3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1040, 620);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_patientnumber);
            this.Controls.Add(this.label_patientname);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button_sendmessage);
            this.Controls.Add(this.textbox_message);
            this.Controls.Add(this.button_file);
            this.Controls.Add(this.chart_mainchart);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DetailedPatientView";
            this.Text = "DetailedPatientView";
            ((System.ComponentModel.ISupportInitialize)(this.chart_mainchart)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HeartrateChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstCadenceChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccPowerChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstPowerChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
			this.textBox1.Location = new System.Drawing.Point(862, 128);
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.textBox1.Size = new System.Drawing.Size(100, 22);
			this.textBox1.TabIndex = 21;
			// 
			// textBox1
			// 
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(968, 127);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 22;
			this.button2.Text = "Set";
			this.button2.Click += new System.EventHandler(this.Button2_Click);
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(859, 108);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 17);
			this.label1.TabIndex = 23;
			this.label1.Text = "Resistance";

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_mainchart;
        private System.Windows.Forms.TextBox textbox_message;
        private System.Windows.Forms.Button button_sendmessage;
        private System.Windows.Forms.PictureBox pictureBox2;
        private User_Controlls.DoctorID doctorID1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Label label_patientname;
        private System.Windows.Forms.Label label_patientnumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart HeartrateChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart SpeedChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart InstCadenceChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart AccPowerChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart InstPowerChart;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
	}
}