using DoktorApp.Communication;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoktorApp.User_Controlls
{
	public partial class DoctorID : UserControl
	{
		private readonly Client client;

		public DoctorID(Client client)
		{
			this.client = client;
			this.InitializeComponent();
			this.SetPlaceHolder(this.textbox_broadcast, "Broadcast:");
			string doctor = client.DoctorName;
			this.Label_DoctorID.Text = doctor;

			if (doctor == "Doctor")
			{
				this.PictureBox_Doctor.Image = Properties.Resources.Doctor;
			}

			if (doctor == "Lavictus")
			{
				this.PictureBox_Doctor.Image = Properties.Resources.Lavictus;
			}

		}

		private void button_sendbroadcast_Click(object sender, EventArgs e)
		{
			this.Broadcast(this.textbox_broadcast.Text);
			this.textbox_broadcast.Clear();
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
			control.GotFocus += delegate (object sender, EventArgs args)
			{
				if (control.Text == PlaceHolderText)
				{
					control.Text = "";
					control.ForeColor = Color.Black;
				}
			};
			control.LostFocus += delegate (object sender, EventArgs args)
			{
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
				this.Broadcast(this.textbox_broadcast.Text);
				this.textbox_broadcast.Clear();
			}
		}
	}
}
