using PlotTest.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlotTest.POCO
{
    [Serializable]
    public class SingleCandlestickLite
    {
        [JsonPropertyName("i")]
        public long Id { get; set; }

        [JsonPropertyName("a")]
        public DateTime OpenTime { get; set; }

        [JsonPropertyName("o")]
        public decimal Open { get; set; }
        [JsonPropertyName("h")]
        public decimal High { get; set; }
        [JsonPropertyName("l")]
        public decimal Low { get; set; }
        [JsonPropertyName("c")]
        public decimal Close { get; set; }
        [JsonPropertyName("v")]
        public decimal Volume { get; set; }

        [JsonPropertyName("b")]
        public DateTime CloseTime { get; set; }

        public SingleCandlestickLite()
        {

        }

        public SingleCandlestickLite(
            long id,
            long openTime,
            decimal open,
            decimal high,
            decimal low,
            decimal close,
            decimal volume,
            long closeTime
            )
        {
            Id = id;

            OpenTime = openTime.ConvertToDateTimeFromUnixMilliseconds();

            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;

            CloseTime = closeTime.ConvertToDateTimeFromUnixMilliseconds();
        }
    }
}
