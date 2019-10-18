namespace ErgoConnect
{
    partial class Form1
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.NameField = new System.Windows.Forms.TextBox();
            this.NumberField = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.ErgoIdLabel = new System.Windows.Forms.Label();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(49, 40);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(83, 15);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Patient naam:";
            // 
            // NumberLabel
            // 
            this.NumberLabel.AutoSize = true;
            this.NumberLabel.Location = new System.Drawing.Point(34, 66);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(98, 15);
            this.NumberLabel.TabIndex = 1;
            this.NumberLabel.Text = "Patient nummer:";
            // 
            // NameField
            // 
            this.NameField.Location = new System.Drawing.Point(138, 37);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(100, 20);
            this.NameField.TabIndex = 2;
            // 
            // NumberField
            // 
            this.NumberField.Location = new System.Drawing.Point(138, 63);
            this.NumberField.Name = "NumberField";
            this.NumberField.Size = new System.Drawing.Size(100, 20);
            this.NumberField.TabIndex = 3;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(37, 115);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(201, 23);
            this.ConfirmButton.TabIndex = 4;
            this.ConfirmButton.Text = "Confirm Data";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ErgoIdLabel
            // 
            this.ErgoIdLabel.AutoSize = true;
            this.ErgoIdLabel.Location = new System.Drawing.Point(80, 92);
            this.ErgoIdLabel.Name = "ErgoIdLabel";
            this.ErgoIdLabel.Size = new System.Drawing.Size(52, 15);
            this.ErgoIdLabel.TabIndex = 5;
            this.ErgoIdLabel.Text = "Ergo Id: ";
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(138, 89);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(100, 20);
            this.IdTextBox.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 188);
            this.Controls.Add(this.IdTextBox);
            this.Controls.Add(this.ErgoIdLabel);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.NumberField);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.NumberLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label NumberLabel;
        private System.Windows.Forms.TextBox NameField;
        private System.Windows.Forms.TextBox NumberField;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label ErgoIdLabel;
        private System.Windows.Forms.TextBox IdTextBox;
    }
}