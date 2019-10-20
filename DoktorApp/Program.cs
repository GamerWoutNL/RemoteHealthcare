using DoktorApp.Communication;
using DoktorApp.Data_Management;
using System;
using System.Windows.Forms;

namespace DoktorApp
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{

			Application.SetCompatibleTextRenderingDefault(false);
			PatientHandler patientHandler = new PatientHandler();
			Client client = new Client(patientHandler);

			client.Connect("localhost", 1717);

			MainView mainView = new MainView(client, patientHandler);
			patientHandler.AttachMainView(mainView);
			patientHandler.AttachClient(client);



			Application.EnableVisualStyles();

			Application.Run(mainView);
		}
	}
}
