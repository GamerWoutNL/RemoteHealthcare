using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoktorApp
{
	public partial class LoginView : Form
	{
		private readonly MainView mainview;
		public LoginView(object obj)
		{
			this.mainview = obj as MainView;
			this.InitializeComponent();
			this.SetPlaceHolder(this.textbox_Username, "Username");
			this.SetPlaceHolder(this.textbox_Username, "Password");



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

		private void Button_Login_Click(object sender, EventArgs e)
		{
			string username = this.textbox_Username.Text;
			string password = this.textbox_Password.Text;

			this.mainview.client.DoctorName = username;
			this.mainview.client.Write($"<{Server.Tag.MT.ToString()}>doctor<{Server.Tag.AC.ToString()}>login<{Server.Tag.UN.ToString()}>{username}<{Server.Tag.PW.ToString()}>{password}<{Server.Tag.EOF.ToString()}>");
			Console.WriteLine("Login Button Pressed");
			this.Close();
			//throw new NotImplementedException();
		}

		private void Textbox_message_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Console.WriteLine("Enter pressed!");
				string username = this.textbox_Username.Text;
				string password = this.textbox_Password.Text;

				this.mainview.client.DoctorName = username;
				this.mainview.client.Write($"<{Server.Tag.MT.ToString()}>doctor<{Server.Tag.AC.ToString()}>login<{Server.Tag.UN.ToString()}>{username}<{Server.Tag.PW.ToString()}>{password}<{Server.Tag.EOF.ToString()}>");
				Console.WriteLine("Login Button Pressed");
				this.Close();
			}

		}

		private void button_quit_Click(object sender, EventArgs e)
		{
			Console.WriteLine("Quit Button Pressed");

			this.mainview.QuitTrue();
			this.Close();
		}

		public void LoginFailed()
		{
			this.textbox_Username.Clear();
		}
	}


}
