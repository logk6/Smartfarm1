using OxyPlot;
using OxyPlot.Series;

namespace Smartfarm1.Models
{
    public class FarmChart
    {
        public PlotModel MyModel { get; set; }
        public FarmChart(IEnumerable<FarmStatus> arr)
        {
            int ind = 0;
            MyModel = new PlotModel { Title = "Farm Plot" };
            var seri = new LineSeries(); seri.Points.Add(new DataPoint(ind, ind));
            var series1 = new LineSeries(); var series2 = new LineSeries(); var series3 = new LineSeries();
           

            foreach (var x in arr)
            {
                ind++;
                series1.Points.Add(new DataPoint(ind, x.CO2));
                series2.Points.Add(new DataPoint(ind, x.SoilMoisture));
                series3.Points.Add(new DataPoint(ind, x.Light_0x5C));
            }

            MyModel.Series.Add(seri);
            MyModel.Series.Add(series1);
            MyModel.Series.Add(series2);
            MyModel.Series.Add(series3);
        }
    }
}
