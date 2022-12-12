using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotTest.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime UnixDt = new DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);

        public static DateTime RoundDT(this DateTime dt)
        {
            var hour = dt.Hour;
            var minute = dt.Minute;

            if (hour == 23 && minute == 59) // end of day
            {
                dt = dt.Date.AddDays(1);
            }
            else if (hour == 0 && minute <= 1) // start of day
            {
                dt = dt.Date;
            }
            else if (minute >= 29 && minute <= 31)
            {
                dt = new DateTime(dt.Year, dt.Month, dt.Day, hour, 30, 0, DateTimeKind.Utc);
            }
            else if (minute <= 1)
            {
                dt = new DateTime(dt.Year, dt.Month, dt.Day, hour, 0, 0, DateTimeKind.Utc);
            }
            else if (minute == 59)
            {
                dt = new DateTime(dt.Year, dt.Month, dt.Day, hour, 0, 0, DateTimeKind.Utc).AddHours(1);
            }

            return dt;
        }

        public static bool IsCorrectDT(this DateTime dt)
        {
            var time = dt.TimeOfDay;
            var minutes = time.TotalMinutes;

            if (minutes % 30 == 0)
            {
                return true;
            }

            return false;
        }

        public static int GetDayStep(this DateTime dt)
        {
            return Convert.ToInt32(dt.TimeOfDay.TotalMinutes) / 30;
        }

        public static DateTime GetDateWithoutSeconds(this DateTime dt)
        {
            return dt.AddSeconds(-dt.Second).AddMilliseconds(-dt.Millisecond);
        }

        public static bool IsStartOfDay(this DateTime dt, out DateTime startOfDayDT)
        {
            startOfDayDT = new DateTime();

            var hour = dt.Hour;
            var minute = dt.Minute;

            if (hour == 23 && minute == 59)
            {
                var tempDT = dt.AddHours(1);
                startOfDayDT = new DateTime(tempDT.Year, tempDT.Month, tempDT.Day, 0, 0, 0, 0, DateTimeKind.Utc);
                return true;
            }

            if (hour == 0 && minute <= 1)
            {
                startOfDayDT = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, DateTimeKind.Utc);
                return true;
            }

            return false;
        }

        public static DateTime GetNextTradeDT(this DateTime dt, int range, out bool isTradeDT)
        {
            isTradeDT = false;

            TimeSpan ts = TimeSpan.FromMinutes(30);
            var date = dt.Date;
            var minutes = range * ts.TotalMinutes;
            TimeSpan tsTotal = TimeSpan.FromMinutes(minutes);

            var nextDT = date.Add(tsTotal);
            if (nextDT < dt)
            {
                return nextDT.AddDays(1);
            }
            else if (nextDT > dt)
            {
                return nextDT;
            }

            isTradeDT = true;
            return nextDT;
        }

        public static long ToUnixSeconds(this DateTime dt)
        {
            return ((DateTimeOffset)dt).ToUnixTimeSeconds();
        }

        public static long ToUnixMilliseconds(this DateTime dt)
        {
            return ((DateTimeOffset)dt).ToUnixTimeMilliseconds();
        }

        public static DateTime ToStartOfMinute(this DateTime currentDt)
        {
            return new DateTime(currentDt.Year, currentDt.Month, currentDt.Day, currentDt.Hour, currentDt.Minute, 0, DateTimeKind.Utc);
        }

        public static DateTime ToEndOfMinute(this DateTime currentDt)
        {
            var startOfMinute = currentDt.ToStartOfMinute();

            return startOfMinute
                .AddMinutes(1)
                .AddMilliseconds(-1);
        }

        public static DateTime GetStartOfDay(this DateTime currentDt)
        {
            return new DateTime(currentDt.Year, currentDt.Month, currentDt.Day, 0, 0, 0, DateTimeKind.Utc);
        }

        public static long TotalSecondsFromStartOfDay(this DateTime dt)
        {
            return (long)dt.TimeOfDay.TotalSeconds;
        }
    }
}
