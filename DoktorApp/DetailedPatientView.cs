using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DoktorApp.Communication;
using Server;
using DoktorApp.Data_Management;
using DoktorApp.User_Controlls;

namespace DoktorApp
{
    public partial class DetailedPatientView : Form
    {
		private Client client;

        private string patientName;
        private string patientNumber;
        private PatientStorage patientStorage;
        FlowLayoutPanel chartpanel;
        Dictionary<DataTag, Chart> chartlist;
        DummyData data = new DummyData();
        

        /// <summary>
        /// Datatags that can be recieved from the bike
        /// </summary>
        public enum DataTag{SP, HR, IC, AP, IP}


     
        public DetailedPatientView(string PatientName, string PatientNumber, Client client, PatientStorage storage)
        {
            this.patientName = PatientName;
            this.patientNumber = PatientNumber;
            this.patientStorage = storage;
            this.client = client;

            InitializeComponent();

            label_patientname.Text = this.patientName;
           
            label_patientnumber.Text = this.patientNumber;

            chartpanel = flowLayoutPanel1;

            //Set placeholders for textboxes
            SetPlaceHolder(textbox_message, "Type message:");
            

            /////Creates Charts for every DataTag
            chartlist = new Dictionary<DataTag, Chart>();
            for (int i = 0; i < 5; i++)
            {
                chartlist.Add(DataTag.SP+i, AddChartInList(GetNamefromTag(DataTag.SP+i)));
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
                case DataTag.SP:
                    return "Speed"; break;
                case DataTag.HR:
                    return "HeartRate"; break;
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


        private void button_sendbutton_Click(object sender, EventArgs e)
        {
            SendToClient(patientStorage.ergoId, textbox_message.Text);
            textbox_message.Clear();
        }

        private void button_file_Click(object sender, EventArgs e)
        {
            Console.WriteLine("File button pressed!");
            this.NotImplemented();
            
        }

        private void textbox_message_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendToClient(patientStorage.ergoId, textbox_message.Text);
                textbox_message.Clear();
            }
            
        }


        private void Button_Stop_Click(object sender, EventArgs e)
        {
			this.EmergencyBrake(patientStorage.ergoId);
		}

        private void button_endsession_click(object sender, EventArgs e)
        {
            this.StopSession(patientStorage.ergoId);
        }

        private void EmergencyBrake(string ergoID)
		{
			this.client.Write($"<{Server.Tag.MT.ToString()}>doctor<{Server.Tag.AC.ToString()}>emergencybrake<{Server.Tag.ID.ToString()}>{ergoID}<{Server.Tag.EOF.ToString()}>");
		}

		private void StopSession(string ergoID)
		{
			this.client.Write($"<{Server.Tag.MT.ToString()}>doctor<{Server.Tag.AC.ToString()}>brake<{Server.Tag.ID.ToString()}>{ergoID}<{Server.Tag.EOF.ToString()}>");
		}

		private void SetResistance(string ergoID, string percentage)
		{
			this.client.Write($"<{Server.Tag.MT.ToString()}>doctor<{Server.Tag.AC.ToString()}>resistance<{Server.Tag.ID.ToString()}>{ergoID}<{Server.Tag.SR.ToString()}>{percentage}<{Server.Tag.EOF.ToString()}>");
		}

		private void Broadcast(string message)
		{
			this.client.Write($"<{Server.Tag.MT.ToString()}>doctor<{Server.Tag.AC.ToString()}>message<{Server.Tag.ID.ToString()}>all<{Server.Tag.DM.ToString()}>{message}<{Server.Tag.EOF.ToString()}>");
		}

		private void SendToClient(string ergoID, string message)
		{
			this.client.Write($"<{Server.Tag.MT.ToString()}>doctor<{Server.Tag.AC.ToString()}>message<{Server.Tag.ID.ToString()}>{ergoID}<{Server.Tag.DM.ToString()}>{message}<{Server.Tag.EOF.ToString()}>");
		}

        private void NotImplemented()
        {
            NotImplementedDialogForm nid = new NotImplementedDialogForm();
            nid.ShowDialog(this);
        }

		private void Button2_Click(object sender, EventArgs e)
		{
			this.SetResistance(patientStorage.ergoId, textBox1.Text);
			textBox1.Clear();
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
