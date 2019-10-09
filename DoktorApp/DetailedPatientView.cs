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
            combobox_clientselection.DisplayMember = "Name";

            chartpanel = flowLayoutPanel1;

            


            for (int i = 0; i < 8; i++)
            {
                chartlist.Add(DataTag.ID+i, AddChartInList(GetNamefromTag(DataTag.ID+i)));
            }
            ChangeMainChart(chartlist[DataTag.HR]);

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
            series.ChartType = SeriesChartType.Line;
            chart.Series.Add(series);
            

           
            var title = new Title();
            title.Name = name;
            title.Text = name;
            chart.Titles.Add(title);

            chart.Visible = true;

            chart.Parent = chartpanel;

            chart.Width = 200;
            chart.Height = 100;

            chart.Click += new System.EventHandler(this.ChartOnClick);

            return chart;
        }

        public void ChartOnClick(object sender, EventArgs e)
        {
            ChangeMainChart(sender as Chart);
        }

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
    }


    public class ClientInfo
    {
        public ClientInfo() { }

        public string Name { get; set; }


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
                newclient.Name = "Mark_" + i;

                clientdata.Add(newclient);
               
            }
        }

       
    }

}
