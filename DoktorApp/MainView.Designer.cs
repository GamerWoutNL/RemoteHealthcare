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
            this.FlowPanelMainView = new System.Windows.Forms.FlowLayoutPanel();
            this.doctorID1 = new DoktorApp.User_Controlls.DoctorID(this.client);
            this.SuspendLayout();
            // 
            // FlowPanelMainView
            // 
            this.FlowPanelMainView.Location = new System.Drawing.Point(16, 158);
            this.FlowPanelMainView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FlowPanelMainView.Name = "FlowPanelMainView";
            this.FlowPanelMainView.Size = new System.Drawing.Size(1307, 677);
            this.FlowPanelMainView.TabIndex = 1;
            // 
            // doctorID1
            // 
            this.doctorID1.BackColor = System.Drawing.Color.Silver;
            this.doctorID1.Location = new System.Drawing.Point(997, 7);
            this.doctorID1.Name = "doctorID1";
            this.doctorID1.Size = new System.Drawing.Size(373, 127);
            this.doctorID1.TabIndex = 2;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 1004);
            this.Controls.Add(this.doctorID1);
            this.Controls.Add(this.FlowPanelMainView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainView";
            this.Text = "MainView";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel FlowPanelMainView;
        private User_Controlls.DoctorID doctorID1;
    }
}