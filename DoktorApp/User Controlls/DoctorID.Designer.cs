namespace DoktorApp.User_Controlls
{
    partial class DoctorID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorID));
            this.PictureBox_Doctor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Doctor)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox_Doctor
            // 
            this.PictureBox_Doctor.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Doctor.Image")));
            this.PictureBox_Doctor.Location = new System.Drawing.Point(202, 0);
            this.PictureBox_Doctor.Name = "PictureBox_Doctor";
            this.PictureBox_Doctor.Size = new System.Drawing.Size(131, 150);
            this.PictureBox_Doctor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox_Doctor.TabIndex = 0;
            this.PictureBox_Doctor.TabStop = false;
            // 
            // DoctorID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PictureBox_Doctor);
            this.Name = "DoctorID";
            this.Size = new System.Drawing.Size(333, 150);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Doctor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox_Doctor;
    }
}
