using OxyPlot.Series;
using PlotTest.Extensions;
using PlotTest.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotTest.Converters
{
    public static class OxyConverter
    {
        public static CandleStickSeries ConvertToPlottalble(IEnumerable<SingleCandlestickLite> candles)
        {
            var result = new CandleStickSeries();

            foreach (var item in candles)
            {
                result.Items.Add(new HighLowItem(
                    item.OpenTime.ToUnixMilliseconds(),
                    decimal.ToDouble(item.High),
                    decimal.ToDouble(item.Low),
                    decimal.ToDouble(item.Open),
                    decimal.ToDouble(item.Close)));
            }

            return result;
        }
    }
}
