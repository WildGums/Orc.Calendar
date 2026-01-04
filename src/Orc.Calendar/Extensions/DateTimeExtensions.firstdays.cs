namespace Orc.Calendar
{
    using System;
    using System.Globalization;
    using Catel.Logging;
    using Microsoft.Extensions.Logging;

    public static partial class DateTimeExtensions
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(DateTimeExtensions));

        public static DateTime GetFirstMondayOfMonth(this DateTime time, CalendarWeekRule calendarWeekRule)
        {
            return GetFirstDayOfMonth(time, calendarWeekRule, DayOfWeek.Monday);
        }

        public static DateTime GetFirstDayOfMonth(this DateTime time, CalendarWeekRule calendarWeekRule, DayOfWeek dayOfWeek)
        {
            return GetFirstDayOfMonth(time, time, calendarWeekRule, dayOfWeek);
        }

        public static DateTime GetFirstMondayOfNextMonth(this DateTime time, CalendarWeekRule calendarWeekRule)
        {
            return GetFirstDayOfNextMonth(time, calendarWeekRule, DayOfWeek.Monday);
        }

        public static DateTime GetFirstDayOfNextMonth(this DateTime time, CalendarWeekRule calendarWeekRule, DayOfWeek dayOfWeek)
        {
            var firstDayOfCurrentMonth = GetFirstDayOfMonth(time, calendarWeekRule, dayOfWeek);

            // Start by adding a month
            var firstDayOfNextMonth = firstDayOfCurrentMonth;
            var trial = firstDayOfCurrentMonth;

            while (firstDayOfNextMonth <= firstDayOfCurrentMonth)
            {
                trial = trial.AddDays(7 * 1);

                firstDayOfNextMonth = trial.GetFirstDayOfMonth(calendarWeekRule, dayOfWeek);
            }

            return firstDayOfNextMonth;
        }

        private static DateTime GetFirstDayOfMonth(this DateTime time, DateTime originalDateTime, CalendarWeekRule calendarWeekRule, DayOfWeek dayOfWeek)
        {
            if (calendarWeekRule != CalendarWeekRule.FirstFourDayWeek)
            {
                throw Logger.LogErrorAndCreateException<NotSupportedException>($"Calendar week rule '{calendarWeekRule}' is not yet supported");
            }

            // Note that we calculated using FirstFourDayWeek and start day of monday,
            // we must calculate the number of days to the previous monday in the current month
            var delta = 0;

            if (time.DayOfWeek != dayOfWeek)
            {
                delta = 0;
                var deltaTime = time;
                var deltaInCurrentMonth = 0;
                var deltaInOtherMonth = 0;

                while (deltaTime.DayOfWeek != dayOfWeek)
                {
                    deltaTime = deltaTime.AddDays(-1);
                    delta--;

                    if (deltaTime.Month == time.Month)
                    {
                        deltaInCurrentMonth++;
                    }
                    else
                    {
                        deltaInOtherMonth++;
                    }
                }

                if (deltaInOtherMonth > 3)
                {
                    // Skip forward instead, we can't fit the 4 days in a week
                    delta = 1;
                    deltaTime = time.AddDays(1);

                    while (deltaTime.DayOfWeek != dayOfWeek)
                    {
                        deltaTime = deltaTime.AddDays(1);
                        delta++;
                    }
                }
            }

            // We use the FirstFourDayWeek
            var weekStart = time.AddDays(delta);

            // At least 4 days must be in the new month
            var firstDayOfMonth = new DateTime(originalDateTime.Year, originalDateTime.Month, 1);
            var minDate = firstDayOfMonth.AddDays(-3);
            var maxDate = firstDayOfMonth.AddDays(3);

            if (weekStart >= minDate && weekStart <= maxDate)
            {
                return weekStart;
            }

            // Pass in the week start as original date/time so we can "skip back" only a single month
            return GetFirstDayOfMonth(weekStart.AddDays(-7), weekStart, calendarWeekRule, dayOfWeek);
        }
    }
}
