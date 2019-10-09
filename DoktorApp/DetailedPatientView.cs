using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DoktorApp
{
    public partial class DetailedPatientView : Form
    {

        FlowLayoutPanel chartpanel;
        Dictionary<DataTag, Chart> chartlist;
        Dumydata data = new Dumydata();

        public enum DataTag{ID, ET, DT, SP, HR, EC, IC, AP, IP}


     
        public DetailedPatientView()
        {
            
            InitializeComponent();
            chartlist = new Dictionary<DataTag, Chart>();
            SetPlaceHolder(textbox_message, "Type message:");

            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            combobox_clientselection.DataSource = data.clientdata;

            chartpanel = flowLayoutPanel1;
            for (int i = 0; i < 8; i++)
            {
                chartlist.Add(DataTag.ID+i, AddChartInList(GetNamefromTag(DataTag.ID+i)));
            }
        }

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
            
            chart.Series.Add(series);


            series.ChartType = SeriesChartType.Line;

           
            var title = new Title();
            title.Name = name;
            title.Text = name;
            chart.Titles.Add(title);

            chart.Visible = true;

            chart.Parent = chartpanel;

            chart.Width = 200;
            chart.Height = 100;

            return chart;
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button Clicked");
        }

        private void DetailedPatientView_Load(object sender, EventArgs e)
        {

        }

        //Textbox 
        public void SetPlaceHolder(Control control, string PlaceHolderText)
        {
            control.Text = PlaceHolderText;
            control.GotFocus += delegate (object sender, EventArgs args) {
                if (control.Text == PlaceHolderText)
                {
                    control.Text = "";
                }
            };
            control.LostFocus += delegate (object sender, EventArgs args) {
                if (control.Text.Length == 0)
                {
                    control.Text = PlaceHolderText;
                }
            };
        }
        //
        
    }

    public class ClientInfo
    {
        public ClientInfo() { }

        public string name { get; set; }
    }


    public class Dumydata
    {

        public List<ClientInfo> clientdata;

        public Dumydata()
        {
            clientdata = new List<ClientInfo>();
            for(int i = 0; i < 10; i++)
            {
                ClientInfo newclient = new ClientInfo();
                newclient.name = "Mark_" + i;
                clientdata.Add(newclient);
            }
        }
    }

}
