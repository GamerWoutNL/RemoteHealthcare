using DoktorApp.Communication;
using DoktorApp.Data_Management;
using DoktorApp.User_Controlls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DoktorApp
{
	public partial class DetailedPatientView : Form
	{
		private readonly Client client;

		private readonly string patientName;
		private readonly string patientNumber;
		private readonly PatientStorage patientStorage;
		private readonly FlowLayoutPanel chartpanel;
		private readonly Dictionary<DataTag, Chart> chartlist;
		private readonly DummyData data = new DummyData();


		/// <summary>
		/// Datatags that can be recieved from the bike
		/// </summary>
		public enum DataTag { SP, HR, IC, AP, IP }



		public DetailedPatientView(string PatientName, string PatientNumber, Client client, PatientStorage storage)
		{
			this.patientName = PatientName;
			this.patientNumber = PatientNumber;
			this.patientStorage = storage;
			this.client = client;

			this.InitializeComponent();

			this.label_patientname.Text = this.patientName;

			this.label_patientnumber.Text = this.patientNumber;

			this.chartpanel = this.flowLayoutPanel1;

			//Set placeholders for textboxes
			this.SetPlaceHolder(this.textbox_message, "Type message:");

			this.patientStorage.AddListeningHeartrateChart(this.HeartrateChart);
			this.patientStorage.AddListeningSpeedChart(this.SpeedChart);
			this.patientStorage.AddListeningInstantaniousCadenceChart(this.InstCadenceChart);
			this.patientStorage.AddListeningAccumulatedPowerChart(this.AccPowerChart);
			this.patientStorage.AddListeningInstantaniousPowerChart(this.InstPowerChart);

			/////Creates Charts for every DataTag
			this.chartlist = new Dictionary<DataTag, Chart>();
			for (int i = 0; i < 5; i++)
			{
				this.chartlist.Add(DataTag.SP + i, this.AddChartInList(this.GetNamefromTag(DataTag.SP + i)));
			}
			this.ChangeMainChart(this.chartlist[DataTag.HR]);
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

			ChartArea chartArea = new ChartArea();
			chartArea.AxisX.LabelStyle.Enabled = false;
			chartArea.AxisY.LabelStyle.Enabled = false;
			chartArea.AxisX.MajorGrid.Enabled = false;
			chartArea.AxisY.MajorGrid.Enabled = false;
			chart.ChartAreas.Add(chartArea);

			Series series = new Series("Data");
			series.Points.DataBindY(new[] { 0, 0, 0, 0 });
			series.ChartType = SeriesChartType.Line;
			chart.Series.Add(series);

			Title title = new Title
			{
				Name = name,
				Text = name
			};
			chart.Titles.Add(title);

			chart.Width = 200;
			chart.Height = 100;
			chart.Parent = this.chartpanel;
			chart.Click += new System.EventHandler(this.ChartOnClick);

			return chart;
		}


		/// <summary>
		/// Eventhandler when a chart is selected
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// 
		public void HeartrateChartClick(object sender, EventArgs e)
		{
			this.chart_mainchart.Series.Clear();
			this.chart_mainchart.Series.Add(ChartUtils.GettSeriesFromDatapoints(this.patientStorage.HeartrateDataPoints));
			this.patientStorage.MainChart = this.chart_mainchart;
			this.chart_mainchart.Titles.Clear();
			this.chart_mainchart.Titles.Add("Heartrate");
			this.patientStorage.MainChartListening = true;
			this.patientStorage.MainChartListeningToData = DataTag.HR.ToString();
		}

		public void SpeedChartClick(object sender, EventArgs e)
		{
			//Chart chart = getChartForMainChart();
			//this.chart_mainchart = chart;
			//this.patientStorage.AddListeningSpeedChart(this.chart_mainchart);
			this.chart_mainchart.Series.Clear();
			this.chart_mainchart.Series.Add(ChartUtils.GettSeriesFromDatapoints(this.patientStorage.SpeedDataPoints));
			this.patientStorage.MainChart = this.chart_mainchart;
			this.chart_mainchart.Titles.Clear();
			this.chart_mainchart.Titles.Add("Speed");
			this.patientStorage.MainChartListening = true;
			this.patientStorage.MainChartListeningToData = DataTag.SP.ToString();
		}

		public void InstantCadenceChartClick(object sender, EventArgs e)
		{
			this.chart_mainchart.Series.Clear();
			this.chart_mainchart.Series.Add(ChartUtils.GettSeriesFromDatapoints(this.patientStorage.InstantaniousCadenceDataPoints));
			this.patientStorage.MainChart = this.chart_mainchart;
			this.chart_mainchart.Titles.Clear();
			this.chart_mainchart.Titles.Add("Instant Cadence");
			this.patientStorage.MainChartListening = true;
			this.patientStorage.MainChartListeningToData = DataTag.IC.ToString();
		}

		public void AccumulatedPowerChartClick(object sender, EventArgs e)
		{
			this.chart_mainchart.Series.Clear();
			this.chart_mainchart.Series.Add(ChartUtils.GettSeriesFromDatapoints(this.patientStorage.AccumulatedPowerDataPoints));
			this.patientStorage.MainChart = this.chart_mainchart;
			this.chart_mainchart.Titles.Clear();
			this.chart_mainchart.Titles.Add("Accumulated Power");
			this.patientStorage.MainChartListening = true;
			this.patientStorage.MainChartListeningToData = DataTag.AP.ToString();
		}

		public void InstantPowerChartClick(object sender, EventArgs e)
		{
			this.chart_mainchart.Series.Clear();
			this.chart_mainchart.Series.Add(ChartUtils.GettSeriesFromDatapoints(this.patientStorage.InstantaniousPowerDataPoints));
			this.patientStorage.MainChart = this.chart_mainchart;
			this.chart_mainchart.Titles.Clear();
			this.chart_mainchart.Titles.Add("Instant Power");
			this.patientStorage.MainChartListening = true;
			this.patientStorage.MainChartListeningToData = DataTag.IP.ToString();
		}

		public Chart getChartForMainChart()
		{
			Chart chart = new Chart
			{
				BackColor = System.Drawing.Color.FromArgb(100, 255, 255, 255),
				BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter
			};

			ChartArea area = new ChartArea
			{
				Name = "ChartArea1"
			};
			chart.ChartAreas.Add(area);

			chart.Location = new System.Drawing.Point(285, 143);
			chart.Margin = new System.Windows.Forms.Padding(2);
			chart.Name = "chart_mainchart";

			Series series1 = new Series
			{
				ChartArea = "ChartArea1",
				ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
				Name = "Series1"
			};

			chart.Series.Add(series1);
			chart.Size = new System.Drawing.Size(613, 390);
			chart.TabIndex = 7;
			chart.Text = "chart1";

			return chart;
		}

		public void ChartOnClick(object sender, EventArgs e)
		{
			this.ChangeMainChart(sender as Chart);
		}


		/// <summary>
		/// Changes the main chart to the selected chart
		/// </summary>
		/// <param name="chart"></param>
		public void ChangeMainChart(Chart chart)
		{

			for (int i = 0; i < this.chart_mainchart.Series.Count; i++)
			{
				this.chart_mainchart.Series.RemoveAt(0);
			}


			for (int i = 0; i < this.chart_mainchart.Titles.Count; i++)
			{
				this.chart_mainchart.Series.RemoveAt(0);
			}

			this.chart_mainchart.Series.Add(chart.Series.ElementAt(0));
			this.chart_mainchart.Titles.Add(chart.Titles.ElementAt(0));
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
			control.GotFocus += delegate (object sender, EventArgs args)
			{
				if (control.Text == PlaceHolderText)
				{
					control.Text = "";
					control.ForeColor = Color.Black;
				}
			};
			control.LostFocus += delegate (object sender, EventArgs args)
			{
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
			this.SendToClient(this.patientStorage.ErgoId, this.textbox_message.Text);
			this.textbox_message.Clear();
		}

		private void button_file_Click(object sender, EventArgs e)
		{
			Console.WriteLine("File button pressed!");
			this.NotImplemented();

		}

		private void textbox_message_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.SendToClient(this.patientStorage.ErgoId, this.textbox_message.Text);
				this.textbox_message.Clear();
			}

		}


		private void Button_Stop_Click(object sender, EventArgs e)
		{
			this.EmergencyBrake(this.patientStorage.ErgoId);
		}

		private void button_endsession_click(object sender, EventArgs e)
		{
			this.StopSession(this.patientStorage.ErgoId);
		}

		private void EmergencyBrake(string ergoID)
		{
			this.client.Write($"<{Server.Tag.MT.ToString()}>doctor<{Server.Tag.AC.ToString()}>emergencybrake<{Server.Tag.ID.ToString()}>{ergoID}<{Server.Tag.EOF.ToString()}>");
		}

		private void StopSession(string ergoID)
		{
			this.client.Write($"<{Server.Tag.MT.ToString()}>doctor<{Server.Tag.AC.ToString()}>brake<{Server.Tag.ID.ToString()}>{ergoID}<{Server.Tag.EOF.ToString()}>");
		}

		private void SetResistance(string ergoID, int percentage)
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

		private void Button3_Click(object sender, EventArgs e)
		{
			if (!int.TryParse(this.resistanceTextBox.Text, out int value))
			{
				return;
			}

			this.SetResistance(this.patientStorage.ErgoId, value);
			this.resistanceTextBox.Clear();
		}



		// /// // /// // /// // /// 
		//
		// /// // /// // /// // /// 
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
		this.clientdata = new List<ClientInfo>();
		for (int i = 0; i < 10; i++)
		{
			ClientInfo newclient = new ClientInfo
			{
				Name = "Mark_" + i
			};

			this.clientdata.Add(newclient);

		}
	}
}


