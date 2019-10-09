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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailedPatientView));
            this.mainchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_file = new System.Windows.Forms.Button();
            this.textbox_message = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_sendbutton = new System.Windows.Forms.Button();
            this.combobox_clientselection = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainchart
            // 
            chartArea2.Name = "ChartArea1";
            this.mainchart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.mainchart.Legends.Add(legend2);
            this.mainchart.Location = new System.Drawing.Point(380, 176);
            this.mainchart.Name = "mainchart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.mainchart.Series.Add(series2);
            this.mainchart.Size = new System.Drawing.Size(817, 480);
            this.mainchart.TabIndex = 7;
            this.mainchart.Text = "chart1";
            // 
            // button_file
            // 
            this.button_file.Location = new System.Drawing.Point(1098, 698);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(99, 23);
            this.button_file.TabIndex = 8;
            this.button_file.Text = "Open File";
            this.button_file.UseVisualStyleBackColor = true;
            this.button_file.Click += new System.EventHandler(this.button1_Click);
            // 
            // textbox_message
            // 
            this.textbox_message.Location = new System.Drawing.Point(380, 125);
            this.textbox_message.Name = "textbox_message";
            this.textbox_message.Size = new System.Drawing.Size(203, 22);
            this.textbox_message.TabIndex = 9;
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
            // 
            // combobox_clientselection
            // 
            this.combobox_clientselection.FormattingEnabled = true;
            this.combobox_clientselection.Location = new System.Drawing.Point(380, 95);
            this.combobox_clientselection.Name = "combobox_clientselection";
            this.combobox_clientselection.Size = new System.Drawing.Size(203, 24);
            this.combobox_clientselection.TabIndex = 12;
            // 
            // DetailedPatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 763);
            this.Controls.Add(this.combobox_clientselection);
            this.Controls.Add(this.button_sendbutton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textbox_message);
            this.Controls.Add(this.button_file);
            this.Controls.Add(this.mainchart);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "DetailedPatientView";
            this.Text = "DetailedPatientView";
            this.Load += new System.EventHandler(this.DetailedPatientView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainchart;
        private System.Windows.Forms.Button button_file;
        private System.Windows.Forms.TextBox textbox_message;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_sendbutton;
        private System.Windows.Forms.ComboBox combobox_clientselection;
    }
}