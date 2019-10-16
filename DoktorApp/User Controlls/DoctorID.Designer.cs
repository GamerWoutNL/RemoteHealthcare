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
            this.Label_DoctorID = new System.Windows.Forms.Label();
            this.textbox_broadcast = new System.Windows.Forms.TextBox();
            this.button_sendbroadcast = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Doctor)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox_Doctor
            // 
            this.PictureBox_Doctor.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Doctor.Image")));
            this.PictureBox_Doctor.Location = new System.Drawing.Point(264, 3);
            this.PictureBox_Doctor.Name = "PictureBox_Doctor";
            this.PictureBox_Doctor.Size = new System.Drawing.Size(106, 120);
            this.PictureBox_Doctor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox_Doctor.TabIndex = 0;
            this.PictureBox_Doctor.TabStop = false;
            // 
            // Label_DoctorID
            // 
            this.Label_DoctorID.AutoSize = true;
            this.Label_DoctorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_DoctorID.Location = new System.Drawing.Point(6, 18);
            this.Label_DoctorID.Name = "Label_DoctorID";
            this.Label_DoctorID.Size = new System.Drawing.Size(244, 29);
            this.Label_DoctorID.TabIndex = 1;
            this.Label_DoctorID.Text = "ReplaceWithDoctorID";
            // 
            // textbox_broadcast
            // 
            this.textbox_broadcast.Location = new System.Drawing.Point(11, 50);
            this.textbox_broadcast.Name = "textbox_broadcast";
            this.textbox_broadcast.Size = new System.Drawing.Size(188, 22);
            this.textbox_broadcast.TabIndex = 15;
            // 
            // button_sendbroadcast
            // 
            this.button_sendbroadcast.Location = new System.Drawing.Point(11, 78);
            this.button_sendbroadcast.Name = "button_sendbroadcast";
            this.button_sendbroadcast.Size = new System.Drawing.Size(75, 26);
            this.button_sendbroadcast.TabIndex = 16;
            this.button_sendbroadcast.Text = "Send";
            this.button_sendbroadcast.UseVisualStyleBackColor = true;
            this.button_sendbroadcast.Click += new System.EventHandler(this.button_sendbroadcast_Click);
            // 
            // DoctorID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.button_sendbroadcast);
            this.Controls.Add(this.textbox_broadcast);
            this.Controls.Add(this.Label_DoctorID);
            this.Controls.Add(this.PictureBox_Doctor);
            this.Name = "DoctorID";
            this.Size = new System.Drawing.Size(373, 124);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Doctor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox_Doctor;
        private System.Windows.Forms.Label Label_DoctorID;
        private System.Windows.Forms.TextBox textbox_broadcast;
        private System.Windows.Forms.Button button_sendbroadcast;
    }
}
