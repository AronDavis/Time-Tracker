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

        public enum RoundDirection
        {
            Up,
            Average,
            Down
        }

        public static TimeSpan Round(TimeSpan time, TimeSpan roundTo, RoundDirection direction = RoundDirection.Average)
        {
            TimeSpan roundedTime;
            long roundedTicks;

            switch(direction)
            {
                case RoundDirection.Up:
                    roundedTicks = (long)Math.Ceiling((double)(time.Ticks) / roundTo.Ticks) * roundTo.Ticks;
                    
                    break;
                case RoundDirection.Down:
                    roundedTicks = (long)Math.Floor((double)(time.Ticks) / roundTo.Ticks) * roundTo.Ticks;
                    roundedTime = new TimeSpan(roundedTicks);
                    break;
                case RoundDirection.Average:
                default:
                    // Default to average
                    roundedTicks = (long)Math.Round((double)(time.Ticks) / roundTo.Ticks) * roundTo.Ticks;
                    break;
            }

            roundedTime = new TimeSpan(roundedTicks);

            return roundedTime;
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
