using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker
{
    class TimeUtility
    {
        public enum RoundIncrementMode
        {
            Seconds,
            Minutes,
            Hours
        }

        public static TimeSpan Round(TimeSpan time, TimeSpan roundTo)
        {
            long roundedTicks = (long)Math.Round((double)(time.Ticks) / roundTo.Ticks) * roundTo.Ticks;

            return new TimeSpan(roundedTicks);
        }

        //TODO: add level of precision?
        public static String FormatRoundedTime(TimeSpan time, RoundIncrementMode mode)
        {
            switch (mode)
            {
                case RoundIncrementMode.Seconds:
                    return (time.Seconds + (time.Milliseconds/ 1000.0)).ToString();
                case RoundIncrementMode.Minutes:
                    return (time.Minutes + (time.Seconds / 60.0)).ToString();
                case RoundIncrementMode.Hours:
                    return (time.Hours + (time.Minutes / 60.0)).ToString();
                default:
                    return "Error";
            }
        }
    }
}
