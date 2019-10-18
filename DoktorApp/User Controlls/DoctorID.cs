using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoktorApp.Communication;

namespace DoktorApp.User_Controlls
{
    public partial class DoctorID : UserControl
    {
        Client client;

        public DoctorID(Client client)
        {
            this.client = client;
            InitializeComponent();
            SetPlaceHolder(textbox_broadcast, "Broadcast:");
            string doctor = client.DoctorName;
            Label_DoctorID.Text = doctor;

            if(doctor == "Doctor")
            {
                PictureBox_Doctor.Image = Properties.Resources.Doctor;
            }

            if (doctor == "Lavictus")
            {
                PictureBox_Doctor.Image = Properties.Resources.Lavictus;
            }

        }

        private void button_sendbroadcast_Click(object sender, EventArgs e)
        {
            Broadcast(textbox_broadcast.Text);
            textbox_broadcast.Clear();
        }

        /// <summary>
        /// Fills a textbox with a text that disappears when clicked on.
        /// Credits: igorpauk at https://stackoverflow.com/questions/11873378/adding-placeholder-text-to-textbox
        /// </summary>
        /// <param name="control"></param>
        /// <param name="PlaceHolderText"></param>
        public void SetPlaceHolder(Control control, string PlaceHolderText)
        {
            control.Text = PlaceHolderText;
            control.ForeColor = Color.Gray;
            control.GotFocus += delegate (object sender, EventArgs args) {
                if (control.Text == PlaceHolderText)
                {
                    control.Text = "";
                    control.ForeColor = Color.Black;
                }
            };
            control.LostFocus += delegate (object sender, EventArgs args) {
                if (control.Text.Length == 0)
                {
                    control.Text = PlaceHolderText;
                    control.ForeColor = Color.Gray;
                }
            };
        }

        private void Broadcast(string message)
        {
            this.client.Write($"<{Server.Tag.MT.ToString()}>doctor<{Server.Tag.AC.ToString()}>message<{Server.Tag.ID.ToString()}>all<{Server.Tag.DM.ToString()}>{message}<{Server.Tag.EOF.ToString()}>");
        }

        private void Textbox_message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Broadcast(textbox_broadcast.Text);
                textbox_broadcast.Clear();
            }
        }
    }
}
