namespace Orc.Calendar
{
    using System;

    public static partial class DateTimeExtensions
    {
        public static DateTime GetMinimum(this DateTime a, DateTime b)
        {
            return a > b ? a : b;
        }

        public static DateTime GetMinimum(this DateTime a, DateTime? b)
        {
            if (!b.HasValue)
            {
                return a;
            }

            return GetMinimum(a, b.Value);
        }

        public static DateTime GetMaximum(this DateTime a, DateTime b)
        {
            return a < b ? a : b;
        }

        public static DateTime GetMaximum(this DateTime a, DateTime? b)
        {
            if (!b.HasValue)
            {
                return a;
            }

            return GetMaximum(a, b.Value);
        }
    }
}
