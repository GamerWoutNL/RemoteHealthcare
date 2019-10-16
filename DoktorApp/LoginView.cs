using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoktorApp
{
    public partial class LoginView : Form
    {
        MainView mainview;
        public LoginView(object obj)
        {
            mainview = obj as MainView;
            InitializeComponent();
            SetPlaceHolder(textbox_Username, "Username");
            SetPlaceHolder(textbox_Username, "Password");


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

        private void Button_Login_Click(object sender, EventArgs e)
        {

            
            Console.WriteLine("Login Button Pressed");

            mainview.LoginTrue();
            this.Close();

            throw new NotImplementedException();
        }

        private void button_quit_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Quit Button Pressed");

            mainview.QuitTrue();
            this.Close();
        }
    }


}
