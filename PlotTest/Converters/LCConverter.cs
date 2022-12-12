using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using PlotTest.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotTest.Converters
{
    public static class LCConverter
    {
        public static CandlesticksSeries<FinancialPoint> ConvertToPlottalble(IEnumerable<SingleCandlestickLite> candles)
        {
            var result = new CandlesticksSeries<FinancialPoint>();

            var values = new List<FinancialPoint>();
            foreach (var item in candles)
            {
                values.Add(new FinancialPoint(
                    item.OpenTime,
                    decimal.ToDouble(item.High),
                    decimal.ToDouble(item.Open),
                    decimal.ToDouble(item.Close),
                    decimal.ToDouble(item.Low)));
            }

            result.Values = values;

            return result;
        }
    }
}
