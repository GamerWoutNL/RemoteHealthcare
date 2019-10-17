using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoktorApp.Communication;
using DoktorApp.Data_Management;

namespace DoktorApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PatientHandler patientHandler = new PatientHandler();
			Client client = new Client(patientHandler);
			client.Connect("localhost", 1717);

            MainView mainView = new MainView(client);
            patientHandler.AttachMainView(mainView);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainView);
		}
	}
}
