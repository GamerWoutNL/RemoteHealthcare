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
            this.button_sendbutton = new System.Windows.Forms.Button();
            this.combobox_clientselection = new System.Windows.Forms.ComboBox();
            this.button_backbutton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_mainchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_backbutton)).BeginInit();
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
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1244, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 118);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 57);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(300, 700);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(300, 700);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // button_sendbutton
            // 
            this.button_sendbutton.Location = new System.Drawing.Point(589, 125);
            this.button_sendbutton.Name = "button_sendbutton";
            this.button_sendbutton.Size = new System.Drawing.Size(75, 26);
            this.button_sendbutton.TabIndex = 11;
            this.button_sendbutton.Text = "Send";
            this.button_sendbutton.UseVisualStyleBackColor = true;
            this.button_sendbutton.Click += new System.EventHandler(this.button_sendbutton_Click);
            // 
            // combobox_clientselection
            // 
            this.combobox_clientselection.FormattingEnabled = true;
            this.combobox_clientselection.Location = new System.Drawing.Point(380, 95);
            this.combobox_clientselection.Name = "combobox_clientselection";
            this.combobox_clientselection.Size = new System.Drawing.Size(203, 24);
            this.combobox_clientselection.TabIndex = 12;
            // 
            // button_backbutton
            // 
            this.button_backbutton.Image = ((System.Drawing.Image)(resources.GetObject("button_backbutton.Image")));
            this.button_backbutton.Location = new System.Drawing.Point(13, 13);
            this.button_backbutton.Name = "button_backbutton";
            this.button_backbutton.Size = new System.Drawing.Size(40, 40);
            this.button_backbutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.button_backbutton.TabIndex = 13;
            this.button_backbutton.TabStop = false;
            this.button_backbutton.Click += new System.EventHandler(this.button_backbutton_Click);
            // 
            // DetailedPatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 763);
            this.Controls.Add(this.button_backbutton);
            this.Controls.Add(this.combobox_clientselection);
            this.Controls.Add(this.button_sendbutton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textbox_message);
            this.Controls.Add(this.button_file);
            this.Controls.Add(this.chart_mainchart);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "DetailedPatientView";
            this.Text = "DetailedPatientView";
            this.Load += new System.EventHandler(this.DetailedPatientView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_mainchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_backbutton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_mainchart;
        private System.Windows.Forms.Button button_file;
        private System.Windows.Forms.TextBox textbox_message;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_sendbutton;
        private System.Windows.Forms.ComboBox combobox_clientselection;
        private System.Windows.Forms.PictureBox button_backbutton;
    }
}