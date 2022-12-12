using LiveChartsCore;
using PlotTest.Converters;
using PlotTest.Extensions;
using PlotTest.PlotForms;
using PlotTest.POCO;

namespace PlotTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<SingleCandlestickLite> GetCanles()
        {
            var candlesFile = "data/candles.json";
            var candlesFileCompressed = candlesFile + ".gz";

            // decompress
            if (!File.Exists(candlesFile))
                FileExtensions.DecompressFile(candlesFileCompressed, candlesFile);

            // load
            var result = FileExtensions.DeserializeJSON<List<SingleCandlestickLite>>(candlesFile);

            // sort just in case
            result = result.OrderBy(o => o.OpenTime).ToList();

            // take a subset
            var countTxt = txtCandlesCount.Text;
            if (!string.IsNullOrEmpty(countTxt))
            {
                result = result.Take(int.Parse(countTxt)).ToList();
            }
            
            return result;
        }

        private void btnPlotCandlesScott_Click(object sender, EventArgs e)
        {
            var candles = GetCanles();
            var plottableCandles = ScottConverter.ConvertToPlottalble(candles);

            var form = new ScottChartForm();
            var plot = form.MainPlot;
            form.Show();

            var candlePlot = plot.Plot.AddCandlesticks(plottableCandles);

            // enable datetimes on X axis
            plot.Plot.XAxis.DateTimeFormat(true);

            plot.Refresh();
        }

        private void btnPlotCandlesOxy_Click(object sender, EventArgs e)
        {
            var candles = GetCanles();
            var plottableCandles = OxyConverter.ConvertToPlottalble(candles);

            var form = new OxyChartForm();
            var plot = form.MainPlot;
            form.Show();

            // create the model and add the lines to it
            var model = new OxyPlot.PlotModel
            {
                Title = $"Candlestick chart"
            };
            model.Series.Add(plottableCandles);

            // load the model into the user control
            plot.Model = model;
        }

        private void btnPlotCandlesLC_Click(object sender, EventArgs e)
        {
            var candles = GetCanles();
            var plottableCandles = LCConverter.ConvertToPlottalble(candles);

            var form = new LCChartForm();
            var plot = form.MainPlot;
            form.Show();

            LiveChartsCore.SkiaSharpView.Axis[] axis = {
                new LiveChartsCore.SkiaSharpView.Axis
                {
                    LabelsRotation = 45,
                    Labeler = value => new DateTime((long)value).ToString("yyyy MMM dd HH mm"),
                    UnitWidth = TimeSpan.FromMinutes(1).Ticks,
                }
            };

            plot.XAxes = axis;
            plot.Series = new ISeries[]
            {
                plottableCandles
            };
        }
    }
}