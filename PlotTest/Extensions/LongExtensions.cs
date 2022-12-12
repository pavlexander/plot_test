using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotTest.Extensions
{
    public static class LongExtensions
    {
        public static DateTime ConvertToDateTimeFromUnixSeconds(this long value)
        {
            return DateTimeExtensions.UnixDt.AddSeconds(value);
        }

        public static DateTime ConvertToDateTimeFromUnixMilliseconds(this long value)
        {
            return DateTimeExtensions.UnixDt.AddMilliseconds(value);
        }
    }
}
