using DoktorApp.Communication;
using DoktorApp.Data_Management;
using System;
using System.Windows.Forms;

namespace DoktorApp
{
	public partial class MainView : Form
	{
		private bool quit;
		public Client client { get; set; }
		public PatientHandler patientHandler { get; set; }

		public MainView(Client client, PatientHandler handler)
		{
			this.client = client;
			this.patientHandler = handler;
			bool login = client.LoggedIn;
			this.quit = false;

			while (true)
			{
				Console.WriteLine(login.ToString());
				login = client.LoggedIn;

				if (login)
				{
					this.InitializeComponent();
					break;
				}
				else if (!this.quit && !login)
				{
					this.Login();
				}
				else if (this.quit)
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
			this.quit = true;
		}

		public void NewClientConnects(string patientName, string patientNumber, Client client, PatientStorage storage)
		{
			SmallPatientView smallPatientView = new SmallPatientView(patientName, patientNumber, client, storage);
			if (this.FlowPanelMainView.InvokeRequired)
			{
				this.FlowPanelMainView.Invoke(new MethodInvoker(delegate { this.NewClientConnects(patientName, patientNumber, client, storage); }));
				return;
			}
			this.FlowPanelMainView.Controls.Add(smallPatientView);
		}

		private void StartSessionButton_Click(object sender, EventArgs e)
		{
			foreach (PatientStorage storage in this.patientHandler.patientStorages)
			{
				if (!this.patientHandler.StorageHasView(storage))
				{
					SmallPatientView patientView = new SmallPatientView(storage.PatientName, storage.PatientNumber, this.client, storage);
					this.patientHandler.addView(storage, patientView);
					this.FlowPanelMainView.Controls.Add(patientView);
				}
			}
		}
	}
}
