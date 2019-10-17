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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailedPatientView));
            this.chart_mainchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_file = new System.Windows.Forms.Button();
            this.textbox_message = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_sendmessage = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.doctorID1 = new DoktorApp.User_Controlls.DoctorID();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.label_patientname = new System.Windows.Forms.Label();
            this.label_patientnumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_mainchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_mainchart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_mainchart.ChartAreas.Add(chartArea1);
            this.chart_mainchart.Location = new System.Drawing.Point(380, 176);
            this.chart_mainchart.Name = "chart_mainchart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chart_mainchart.Series.Add(series1);
            this.chart_mainchart.Size = new System.Drawing.Size(817, 480);
            this.chart_mainchart.TabIndex = 7;
            this.chart_mainchart.Text = "chart1";
            // 
            // button_file
            // 
            this.button_file.Location = new System.Drawing.Point(1098, 698);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(99, 26);
            this.button_file.TabIndex = 8;
            this.button_file.Text = "Open File";
            this.button_file.UseVisualStyleBackColor = true;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // textbox_message
            // 
            this.textbox_message.Location = new System.Drawing.Point(380, 125);
            this.textbox_message.Name = "textbox_message";
            this.textbox_message.Size = new System.Drawing.Size(203, 22);
            this.textbox_message.TabIndex = 9;
            this.textbox_message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_message_KeyDown);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.DataBindings.Add(new System.Windows.Forms.Binding("FlowDirection", global::DoktorApp.Properties.Settings.Default, "flowtopdown", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel1.FlowDirection = global::DoktorApp.Properties.Settings.Default.flowtopdown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 29);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(300, 700);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(300, 700);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // button_sendmessage
            // 
            this.button_sendmessage.Location = new System.Drawing.Point(589, 125);
            this.button_sendmessage.Name = "button_sendmessage";
            this.button_sendmessage.Size = new System.Drawing.Size(75, 26);
            this.button_sendmessage.TabIndex = 11;
            this.button_sendmessage.Text = "Send";
            this.button_sendmessage.UseVisualStyleBackColor = true;
            this.button_sendmessage.Click += new System.EventHandler(this.button_sendbutton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(682, 65);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(94, 86);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // doctorID1
            // 
            this.doctorID1.BackColor = System.Drawing.Color.Silver;
            this.doctorID1.Location = new System.Drawing.Point(1012, 2);
            this.doctorID1.Name = "doctorID1";
            this.doctorID1.Size = new System.Drawing.Size(372, 124);
            this.doctorID1.TabIndex = 17;
            // 
            // label_patientname
            // 
            this.label_patientname.AutoSize = true;
            this.label_patientname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label_patientname.Location = new System.Drawing.Point(375, 65);
            this.label_patientname.Name = "label_patientname";
            this.label_patientname.Size = new System.Drawing.Size(289, 29);
            this.label_patientname.TabIndex = 18;
            this.label_patientname.Text = "ReplaceWithPatientName";
            // 
            // label_patientnumber
            // 
            this.label_patientnumber.AutoSize = true;
            this.label_patientnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_patientnumber.Location = new System.Drawing.Point(375, 93);
            this.label_patientnumber.Name = "label_patientnumber";
            this.label_patientnumber.Size = new System.Drawing.Size(173, 20);
            this.label_patientnumber.TabIndex = 19;
            this.label_patientnumber.Text = "ReplaceWithPatientID";
            // 
            // DetailedPatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 763);
            this.Controls.Add(this.label_patientnumber);
            this.Controls.Add(this.label_patientname);
            this.Controls.Add(this.doctorID1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button_sendmessage);
            this.Controls.Add(this.textbox_message);
            this.Controls.Add(this.button_file);
            this.Controls.Add(this.chart_mainchart);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DetailedPatientView";
            this.Text = "DetailedPatientView";
            ((System.ComponentModel.ISupportInitialize)(this.chart_mainchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_mainchart;
        private System.Windows.Forms.Button button_file;
        private System.Windows.Forms.TextBox textbox_message;
        private System.Windows.Forms.Button button_sendmessage;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private User_Controlls.DoctorID doctorID1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Label label_patientname;
        private System.Windows.Forms.Label label_patientnumber;
    }
}