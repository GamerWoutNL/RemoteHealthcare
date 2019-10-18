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
