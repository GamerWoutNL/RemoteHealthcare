using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoktorApp.Communication;
using DoktorApp.Data_Management;

namespace DoktorApp
{
    public partial class MainView : Form
    {
        
        public bool quit;
        public Client client;

        public MainView(Client client)
        {
            this.client = client;
            bool login = client.LoggedIn;
            this.quit = false;


            while (true)
            {
                Console.WriteLine(login.ToString());
                login = client.LoggedIn;

                if (login)
                {
                    InitializeComponent();

                    //when client connects

                    NewClientConnects("test", "123", client, new PatientStorage("test", "123"));
                    break;
                }
                else if(!quit && !login)
                {
                    Login();
                }
                else if (quit)
                {
                    Environment.Exit(1);
                    this.Close();
                }
            }
        }


        public void Login()
        {
            LoginView loginView = new LoginView(this);
            loginView.ShowDialog();
        }


        public void QuitTrue()
        {
            quit = true;
            
        }

        public void NewClientConnects(string patientName, string patientNumber, Client client, PatientStorage storage)
        {
            SmallPatientView smallPatientView = new SmallPatientView(patientName, patientNumber, client, storage);
            this.FlowPanelMainView.Controls.Add(smallPatientView);
        }
    }
}
