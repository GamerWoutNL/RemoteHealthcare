namespace DoktorApp
{
    partial class LoginView
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
            this.textbox_Username = new System.Windows.Forms.TextBox();
            this.textbox_Password = new System.Windows.Forms.TextBox();
            this.Button_Login = new System.Windows.Forms.Button();
            this.button_quit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textbox_Username
            // 
            this.textbox_Username.Location = new System.Drawing.Point(304, 143);
            this.textbox_Username.Name = "textbox_Username";
            this.textbox_Username.Size = new System.Drawing.Size(188, 22);
            this.textbox_Username.TabIndex = 16;
            this.textbox_Username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Textbox_message_KeyDown);
            // 
            // textbox_Password
            // 
            this.textbox_Password.Location = new System.Drawing.Point(304, 189);
            this.textbox_Password.Name = "textbox_Password";
            this.textbox_Password.PasswordChar = '*';
            this.textbox_Password.Size = new System.Drawing.Size(188, 22);
            this.textbox_Password.TabIndex = 17;
            this.textbox_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Textbox_message_KeyDown);
            // 
            // Button_Login
            // 
            this.Button_Login.Location = new System.Drawing.Point(304, 217);
            this.Button_Login.Name = "Button_Login";
            this.Button_Login.Size = new System.Drawing.Size(188, 30);
            this.Button_Login.TabIndex = 18;
            this.Button_Login.Text = "Login";
            this.Button_Login.UseVisualStyleBackColor = true;
            this.Button_Login.Click += new System.EventHandler(this.Button_Login_Click);
            // 
            // button_quit
            // 
            this.button_quit.Location = new System.Drawing.Point(304, 253);
            this.button_quit.Name = "button_quit";
            this.button_quit.Size = new System.Drawing.Size(188, 30);
            this.button_quit.TabIndex = 19;
            this.button_quit.Text = "Quit";
            this.button_quit.UseVisualStyleBackColor = true;
            this.button_quit.Click += new System.EventHandler(this.button_quit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Gebruikersnaam:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Wachtwoord:";
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DoktorApp.Properties.Resources.Hospital2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_quit);
            this.Controls.Add(this.Button_Login);
            this.Controls.Add(this.textbox_Password);
            this.Controls.Add(this.textbox_Username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoginView";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_Username;
        private System.Windows.Forms.TextBox textbox_Password;
        private System.Windows.Forms.Button Button_Login;
        private System.Windows.Forms.Button button_quit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}