using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoktorApp
{
    public partial class SmallPatientView : UserControl
    {
        public SmallPatientView()
        {
            InitializeComponent();
        }

        public SmallPatientView(string PatientName, string PatientNumber)
        {
            InitializeComponent();
            this.PatientNameLabel.Text = $"Patient naam: {PatientName}";
            this.PatientNumberLabel.Text = $"Patient nummer: {PatientNumber}";
        }

        private void PatientNameLabel_Click(object sender, EventArgs e)
        {
            DetailedPatientView patientView = new DetailedPatientView();
            patientView.Show();
        }
    }
}
