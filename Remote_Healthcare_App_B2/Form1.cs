using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ErgoConnect
{
    public partial class Form1 : Form
    {
		private Program program;
        public Form1(Program program)
        {
			this.program = program;
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            string patientName = this.NameField.Text;
            string patientNumber = this.NumberField.Text;
            string ergoId = this.IdTextBox.Text;

			program.Connect(ergoId, patientName, patientNumber);
        }

        
    }
}
