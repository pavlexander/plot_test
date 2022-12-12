using OxyPlot.Series;
using PlotTest.POCO;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotTest.Converters
{
    public static class ScottConverter
    {
        public static OHLC[] ConvertToPlottalble(IEnumerable<SingleCandlestickLite> input)
        {
            var result = new List<OHLC>();

            if (input != null && input.Any())
            {
                foreach (var item in input)
                {
                    result.Add(
                        new OHLC(
                            decimal.ToDouble(item.Open),
                            decimal.ToDouble(item.High),
                            decimal.ToDouble(item.Low),
                            decimal.ToDouble(item.Close),
                            item.OpenTime,
                            TimeSpan.FromMinutes(1),
                            decimal.ToDouble(item.Volume))
                        );
                }
            }

            return result.ToArray();
        }
    }
}
