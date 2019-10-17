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
    public partial class MainView : Form
    {
        public bool login;
        public bool quit;

        public MainView()
        {
            login = false;
            quit = false;
            

            while (!login && !quit) { Login(); }


            if (login)
            {
                InitializeComponent();

                //when client connects
                SmallPatientView smallPatientView1 = new SmallPatientView("Test", "123");
                SmallPatientView smallPatientView2 = new SmallPatientView("Test2", "1234");
                this.FlowPanelMainView.Controls.Add(smallPatientView1);
                this.FlowPanelMainView.Controls.Add(smallPatientView2);
            }
            if (quit)
            {
                Environment.Exit(1);
                this.Close();
            }
            
           
               

        }


        public void Login()
        {
            LoginView loginView = new LoginView(this);
            loginView.ShowDialog();
        }

        public void LoginTrue()
        {
            login = true;
        }

        public void QuitTrue()
        {
            quit = true;
        }
    }
}
