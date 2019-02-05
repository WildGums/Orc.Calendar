namespace Orc.Calendar
{
    using System;
    using System.Globalization;

    public static partial class DateTimeExtensions
    {
        public static int GetWeekOfMonth(this DateTime dt, CalendarWeekRule calendarWeekRule, DayOfWeek firstDayOfWeek)
        {
            var firstMondayOfMonth = dt.GetFirstDayOfMonth(calendarWeekRule, firstDayOfWeek);
            var weekOfYear = dt.GetWeekOfYear(calendarWeekRule, firstDayOfWeek);

            if ((weekOfYear < 6) &&
                (firstMondayOfMonth.Month == 1 || firstMondayOfMonth.Month == 12))
            {
                //week of year == week of month in January
                //this also fixes the overflowing last December week
                return weekOfYear;
            }

            var weekOfYearAtFirstMonday = firstMondayOfMonth.GetWeekOfYear(calendarWeekRule, firstDayOfWeek);
            return (weekOfYear - weekOfYearAtFirstMonday) + 1;
        }

        public static int GetWeekOfYear(this DateTime dt, CalendarWeekRule calendarWeekRule, DayOfWeek firstDayOfWeek)
        {
            var weekOfYear = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dt, calendarWeekRule, firstDayOfWeek);
            return weekOfYear;
        }

        public static int CalculateNoOfWeeks(this DateTime startDate, DateTime endDate)
        {
            var delta = endDate - startDate;
            return (int)(delta.TotalDays / 7);
        }

        public static int CalculateNoOfWeeks(this DateTime? startDate, DateTime? endDate)
        {
            if (!startDate.HasValue || !endDate.HasValue)
            {
                return 0;
            }

            return CalculateNoOfWeeks(startDate.Value, endDate.Value);
        }
    }
}
