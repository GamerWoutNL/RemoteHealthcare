using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;



namespace DoktorApp
{
    class ChartUtils
    {

        static void addDatapointToListForChart(CustomDatapoint datapoint,List<CustomDatapoint> customDatapoints, Chart Chart)
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

    }
}
