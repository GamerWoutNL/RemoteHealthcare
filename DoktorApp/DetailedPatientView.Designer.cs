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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_sendmessage = new System.Windows.Forms.Button();
            this.button_sendbroadcast = new System.Windows.Forms.Button();
            this.textbox_broadcast = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Text_DoctorID = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.chart_mainchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_mainchart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_mainchart.ChartAreas.Add(chartArea1);
            this.chart_mainchart.Location = new System.Drawing.Point(285, 143);
            this.chart_mainchart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.button_file.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(74, 21);
            this.button_file.TabIndex = 8;
            this.button_file.Text = "Open File";
            this.button_file.UseVisualStyleBackColor = true;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // textbox_message
            // 
            this.textbox_message.Location = new System.Drawing.Point(285, 102);
            this.textbox_message.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textbox_message.Name = "textbox_message";
            this.textbox_message.Size = new System.Drawing.Size(153, 20);
            this.textbox_message.TabIndex = 9;
            this.textbox_message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_message_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(933, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.DataBindings.Add(new System.Windows.Forms.Binding("FlowDirection", global::DoktorApp.Properties.Settings.Default, "flowtopdown", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel1.FlowDirection = global::DoktorApp.Properties.Settings.Default.flowtopdown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 24);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(225, 569);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(225, 569);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // button_sendmessage
            // 
            this.button_sendmessage.Location = new System.Drawing.Point(442, 102);
            this.button_sendmessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_sendmessage.Name = "button_sendmessage";
            this.button_sendmessage.Size = new System.Drawing.Size(56, 21);
            this.button_sendmessage.TabIndex = 11;
            this.button_sendmessage.Text = "Send";
            this.button_sendmessage.UseVisualStyleBackColor = true;
            this.button_sendmessage.Click += new System.EventHandler(this.button_sendbutton_Click);
            // 
            // button_sendbroadcast
            // 
            this.button_sendbroadcast.Location = new System.Drawing.Point(872, 67);
            this.button_sendbroadcast.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_sendbroadcast.Name = "button_sendbroadcast";
            this.button_sendbroadcast.Size = new System.Drawing.Size(56, 21);
            this.button_sendbroadcast.TabIndex = 15;
            this.button_sendbroadcast.Text = "Send";
            this.button_sendbroadcast.UseVisualStyleBackColor = true;
            this.button_sendbroadcast.Click += new System.EventHandler(this.button_sendbroadcast_Click);
            // 
            // textbox_broadcast
            // 
            this.textbox_broadcast.Location = new System.Drawing.Point(719, 68);
            this.textbox_broadcast.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textbox_broadcast.Name = "textbox_broadcast";
            this.textbox_broadcast.Size = new System.Drawing.Size(153, 20);
            this.textbox_broadcast.TabIndex = 14;
            this.textbox_broadcast.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_broadcast_KeyDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(512, 53);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // Text_DoctorID
            // 
            this.Text_DoctorID.BackColor = System.Drawing.SystemColors.Info;
            this.Text_DoctorID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Text_DoctorID.Location = new System.Drawing.Point(719, 36);
            this.Text_DoctorID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Text_DoctorID.Name = "Text_DoctorID";
            this.Text_DoctorID.ReadOnly = true;
            this.Text_DoctorID.Size = new System.Drawing.Size(209, 13);
            this.Text_DoctorID.TabIndex = 17;
            this.Text_DoctorID.Text = "Replace With Doctor ID";
            // 
            // DetailedPatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 620);
            this.Controls.Add(this.Text_DoctorID);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button_sendbroadcast);
            this.Controls.Add(this.textbox_broadcast);
            this.Controls.Add(this.button_sendmessage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textbox_message);
            this.Controls.Add(this.button_file);
            this.Controls.Add(this.chart_mainchart);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DetailedPatientView";
            this.Text = "DetailedPatientView";
            this.Load += new System.EventHandler(this.DetailedPatientView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_mainchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_mainchart;
        private System.Windows.Forms.Button button_file;
        private System.Windows.Forms.TextBox textbox_message;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_sendmessage;
        private System.Windows.Forms.Button button_sendbroadcast;
        private System.Windows.Forms.TextBox textbox_broadcast;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox Text_DoctorID;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}