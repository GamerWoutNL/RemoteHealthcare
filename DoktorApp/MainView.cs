﻿using System;
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
        public MainView()
        {
            InitializeComponent();



            //when client connects
            SmallPatientView smallPatientView1 = new SmallPatientView("Test", "123");
            SmallPatientView smallPatientView2 = new SmallPatientView("Test2", "1234");
            this.FlowPanelMainView.Controls.Add(smallPatientView1);
            this.FlowPanelMainView.Controls.Add(smallPatientView2);

        }
    }
}
