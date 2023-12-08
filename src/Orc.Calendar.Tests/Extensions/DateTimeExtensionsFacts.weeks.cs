namespace Orc.Calendar.Tests
{
    using System;
    using System.Collections;
    using System.Globalization;
    using NUnit.Framework;

    public partial class DateTimeExtensionsFacts
    {
        [Test, TestCaseSource(typeof(DateTimeExtensionsFacts), nameof(GetWeekOfYearCases))]
        public int GetWeekOfYear(DateTime date, CalendarWeekRule calendarWeekRule, DayOfWeek firstDayOfWeek)
        {
            var actual = date.GetWeekOfYear(calendarWeekRule, firstDayOfWeek);
            return actual;
        }

        public static IEnumerable GetWeekOfYearCases
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 01, 01), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(1);
                yield return new TestCaseData(new DateTime(2019, 01, 04), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(1);
                yield return new TestCaseData(new DateTime(2019, 01, 26), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(4);
                yield return new TestCaseData(new DateTime(2019, 02, 03), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(5);
                yield return new TestCaseData(new DateTime(2019, 02, 04), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(6);
                yield return new TestCaseData(new DateTime(2019, 02, 14), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(7);
            }
        }

        [Test, TestCaseSource(typeof(DateTimeExtensionsFacts), nameof(GetWeekOfMonthCases))]
        public int GetWeekOfMonth(DateTime date, CalendarWeekRule calendarWeekRule, DayOfWeek firstDayOfWeek)
        {
            var actual = date.GetWeekOfMonth(calendarWeekRule, firstDayOfWeek);
            return actual;
        }

        public static IEnumerable GetWeekOfMonthCases
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 01, 01), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(1);
                yield return new TestCaseData(new DateTime(2019, 01, 04), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(1);
                yield return new TestCaseData(new DateTime(2019, 01, 26), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(4);
                yield return new TestCaseData(new DateTime(2019, 02, 03), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(5);
                yield return new TestCaseData(new DateTime(2019, 02, 04), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(1);
                yield return new TestCaseData(new DateTime(2019, 02, 14), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(2);
            }
        }
    }
}
