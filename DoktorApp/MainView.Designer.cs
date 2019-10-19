namespace DoktorApp
{
    partial class MainView
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
            this.doctorID1 = new User_Controlls.DoctorID(this.client);
            this.FlowPanelMainView = new System.Windows.Forms.FlowLayoutPanel();
            this.StartSessionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // doctorID1
            // 
            this.doctorID1.Location = new System.Drawing.Point(750, 7);
            this.doctorID1.Name = "doctorID1";
            this.doctorID1.Size = new System.Drawing.Size(373, 127);
            this.doctorID1.TabIndex = 2;
            // 
            // FlowPanelMainView
            // 
            this.FlowPanelMainView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.FlowPanelMainView.Location = new System.Drawing.Point(12, 128);
            this.FlowPanelMainView.Name = "FlowPanelMainView";
            this.FlowPanelMainView.Size = new System.Drawing.Size(940, 550);
            this.FlowPanelMainView.TabIndex = 1;
            
            // 
            // StartSessionButton
            // 
            this.StartSessionButton.Location = new System.Drawing.Point(12, 99);
            this.StartSessionButton.Name = "StartSessionButton";
            this.StartSessionButton.Size = new System.Drawing.Size(156, 23);
            this.StartSessionButton.TabIndex = 0;
            this.StartSessionButton.Text = "Start session";
            this.StartSessionButton.UseVisualStyleBackColor = true;
            this.StartSessionButton.Click += new System.EventHandler(this.StartSessionButton_Click);

            // 
            // MainView
            // 
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DoktorApp.Properties.Resources.Hospital4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1030, 816);
            this.Controls.Add(this.StartSessionButton);
            this.Controls.Add(this.FlowPanelMainView);
            this.Controls.Add(this.doctorID1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainView";
            this.Text = "MainView";
            this.ResumeLayout(false);

        }

        #endregion
        private User_Controlls.DoctorID doctorID1;
        private System.Windows.Forms.FlowLayoutPanel FlowPanelMainView;

       
        private System.Windows.Forms.Button StartSessionButton;

    }
}