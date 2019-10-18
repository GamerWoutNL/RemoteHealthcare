using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace DoktorApp
{
    class ChartUtils
    {

        public static void addDatapointToListForChart(CustomDatapoint datapoint,List<CustomDatapoint> customDatapoints, Chart Chart)
        {
            customDatapoints.Add(datapoint);
            customDatapoints.Sort((x, y) => y.timestamp.CompareTo(x.timestamp));
            Chart.Series.Clear();

            Series series1 = new Series();
            series1.ChartType = SeriesChartType.Line;

            int counter = 1;
            foreach (CustomDatapoint datapoint1 in customDatapoints)
            {
                series1.Points.Add(new DataPoint(counter, datapoint1.data));
                counter++;
            }

            Chart.Series.Add(series1);
        }

        public static void updateChart(Chart chart, List<CustomDatapoint> datapoints)
        {
            datapoints.Sort((x, y) => x.timestamp.CompareTo(y.timestamp));

            

            Series series1 = new Series();
            series1.ChartType = SeriesChartType.Line;

            int counter = 1;
            if (datapoints.Count > 240)
            {
                foreach (CustomDatapoint datapoint1 in datapoints.GetRange(datapoints.Count - 240, 240))
                {
                    series1.Points.Add(new DataPoint(counter, datapoint1.data));
                    counter++;
                }
            } else
            {
                foreach(CustomDatapoint datapoint in datapoints)
                {
                    series1.Points.Add(new DataPoint(counter, datapoint.data));
                    counter++;
                }
            }

            if (chart.InvokeRequired)
            {
                chart.Invoke(new MethodInvoker(delegate { updateChart(chart, datapoints); }));
                return;
            }
            chart.Series.Clear();
            chart.Series.Add(series1);
            
        }
    }
}
