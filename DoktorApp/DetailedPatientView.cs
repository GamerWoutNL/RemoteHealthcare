﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DoktorApp.Communication;

namespace DoktorApp
{
    public partial class DetailedPatientView : Form
    {
		private Client client;
        FlowLayoutPanel chartpanel;
        Dictionary<DataTag, Chart> chartlist;
        DummyData data = new DummyData();

        /// <summary>
        /// Datatags that can be recieved from the bike
        /// </summary>
        public enum DataTag{ID, ET, DT, SP, HR, EC, IC, AP, IP}


     
        public DetailedPatientView(Client client)
        {
			this.client = client;
            InitializeComponent();
            chartpanel = flowLayoutPanel1;

            //Set placeholders for textboxes
            SetPlaceHolder(textbox_message, "Type message:");
            

            /////Creates Charts for every DataTag
            chartlist = new Dictionary<DataTag, Chart>();
            for (int i = 0; i < 8; i++)
            {
                chartlist.Add(DataTag.ID+i, AddChartInList(GetNamefromTag(DataTag.ID+i)));
            }
            ChangeMainChart(chartlist[DataTag.HR]);
            /////
        }

        /// <summary>
        /// Creates a small chart in the chartflowpanel
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Chart AddChartInList(string name)
        {
            Chart chart = new Chart();

            var chartArea = new ChartArea();
            chartArea.AxisX.LabelStyle.Enabled = false;
            chartArea.AxisY.LabelStyle.Enabled = false;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas.Add(chartArea);

            var series = new Series("Data");
            series.Points.DataBindY(new[] { 0, 0, 0, 0 });
            series.ChartType = SeriesChartType.Line;
            chart.Series.Add(series);
            
            var title = new Title();
            title.Name = name;
            title.Text = name;
            chart.Titles.Add(title);
            
            chart.Width = 200;
            chart.Height = 100;
            chart.Parent = chartpanel;
            chart.Click += new System.EventHandler(this.ChartOnClick);

            return chart;
        }


        /// <summary>
        /// Eventhandler when a chart is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ChartOnClick(object sender, EventArgs e)
        {
            ChangeMainChart(sender as Chart);
        }


        /// <summary>
        /// Changes the main chart to the selected chart
        /// </summary>
        /// <param name="chart"></param>
        public void ChangeMainChart(Chart chart)
        {
            for(int i = 0; i< chart_mainchart.Series.Count; i++)
            {
                chart_mainchart.Series.RemoveAt(0);
            }

            for (int i = 0; i < chart_mainchart.Titles.Count; i++)
            {
                chart_mainchart.Titles.RemoveAt(0);
            }

            chart_mainchart.Series.Add(chart.Series.ElementAt(0));
            chart_mainchart.Titles.Add(chart.Titles.ElementAt(0));
        }

        /// <summary>
        /// Translates a DataTag(enum) to a string
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string GetNamefromTag(DataTag tag)
        {
            switch (tag)
            {
                case DataTag.ID:
                    return "Identification"; break;
                case DataTag.ET:
                    return "Elapsed Time"; break;
                case DataTag.DT:
                    return "Distance Traveled"; break;
                case DataTag.SP:
                    return "Speed"; break;
                case DataTag.HR:
                    return "HeartRate"; break;
                case DataTag.EC:
                    return "Event Count"; break;
                case DataTag.IC:
                    return "Instantanious Cadence"; break;
                case DataTag.AP:
                    return "Accumulated Power"; break;
                case DataTag.IP:
                    return "Instantanious Power"; break;
                default:
                    return null;
            }
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


        // /// // /// // /// // /// 
        // Eventhandlers 
        // /// // /// // /// // /// 

        private void button_backbutton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Back button pressed!");
            throw new NotImplementedException();
        }

        private void button_sendbutton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Send button pressed!");
            throw new NotImplementedException();
        }

        private void button_file_Click(object sender, EventArgs e)
        {
            Console.WriteLine("File button pressed!");
            throw new NotImplementedException();
        }

        private void textbox_message_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Console.WriteLine("Enter pressed!");
                throw new NotImplementedException();
            }
            
        }

        private void textbox_broadcast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Console.WriteLine("Enter pressed!");
                throw new NotImplementedException();
            }

        }


        private void button_sendbroadcast_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Send button pressed!");
            throw new NotImplementedException();
        }

        private void Button_Stop_Click(object sender, EventArgs e)
        {
			//this.EmergencyBrake("00472");
			this.Broadcast("testtesttesttesttesttest");
		}

		private void EmergencyBrake(string ergoID)
		{
			this.client.Write($"<MT>doctor<AC>emergencybrake<ID>{ergoID}<EOF>");
		}

		private void StopSession(string ergoID)
		{
			this.client.Write($"<MT>doctor<AC>brake<ID>{ergoID}<EOF>");
		}

		private void SetResistance(string ergoID, int percentage)
		{
			this.client.Write($"<MT>doctor<AC>resistance<ID>{ergoID}<SR>{percentage}<EOF>");
		}

		private void Login(string username, string password)
		{
			this.client.Write($"<MT>doctor<AC>login<UN>{username}<PW>{password}<EOF>");
		}

		private void Broadcast(string message)
		{
			this.client.Write($"<MT>doctor<AC>message<ID>all<DM>{message}<EOF>");
		}

		private void SendToClient(string ergoID, string message)
		{
			this.client.Write($"<MT>doctor<AC>message<ID>{ergoID}<DM>{message}<EOF>");
		}

		// /// // /// // /// // /// 
		//
		// /// // /// // /// // /// 
	}



    /// <summary>
    /// Basic info class for dummy data
    /// </summary>
    public class ClientInfo
    {
        public ClientInfo() { }
        public string Name { get; set; }
    }


    /// <summary>
    /// Class that creates a list of dumy data
    /// </summary>
    public class DummyData
    {
        public List<ClientInfo> clientdata;
        public DummyData()
        {
            clientdata = new List<ClientInfo>();
            for(int i = 0; i < 10; i++)
            {
                ClientInfo newclient = new ClientInfo();
                newclient.Name = "Mark_" + i;

                clientdata.Add(newclient);
               
            }
        }
    }

}
