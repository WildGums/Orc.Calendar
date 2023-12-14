namespace Orc.Calendar.Tests
{
    using System;
    using System.Collections;
    using System.Globalization;
    using NUnit.Framework;

    public partial class DateTimeExtensionsFacts
    {
        [Test, TestCaseSource(typeof(DateTimeExtensionsFacts), nameof(GetFirstDayOfMonthCases))]
        public DateTime GetFirstDayOfMonth(DateTime date, CalendarWeekRule calendarWeekRule, DayOfWeek firstDayOfWeek)
        {
            var actual = date.GetFirstDayOfMonth(calendarWeekRule, firstDayOfWeek);
            return actual;
        }

        public static IEnumerable GetFirstDayOfMonthCases
        {
            get
            {
                yield return new TestCaseData(new DateTime(2018, 06, 01), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(new DateTime(2018, 06, 04));
                yield return new TestCaseData(new DateTime(2018, 11, 01), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(new DateTime(2018, 10, 29));
                yield return new TestCaseData(new DateTime(2018, 12, 01), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(new DateTime(2018, 12, 03));
                yield return new TestCaseData(new DateTime(2019, 01, 01), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(new DateTime(2018, 12, 31));
                yield return new TestCaseData(new DateTime(2019, 01, 04), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(new DateTime(2018, 12, 31));
                yield return new TestCaseData(new DateTime(2019, 01, 26), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(new DateTime(2018, 12, 31));
                yield return new TestCaseData(new DateTime(2019, 02, 03), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(new DateTime(2019, 02, 04));
                yield return new TestCaseData(new DateTime(2019, 02, 04), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(new DateTime(2019, 02, 04));
                yield return new TestCaseData(new DateTime(2019, 02, 14), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(new DateTime(2019, 02, 04));
            }
        }

        [Test, TestCaseSource(typeof(DateTimeExtensionsFacts), nameof(GetFirstDayOfNextMonthCases))]
        public DateTime GetFirstMondayNextOfMonth(DateTime date, CalendarWeekRule calendarWeekRule, DayOfWeek firstDayOfWeek)
        {
            var actual = date.GetFirstDayOfNextMonth(calendarWeekRule, firstDayOfWeek);
            return actual;
        }

        public static IEnumerable GetFirstDayOfNextMonthCases
        {
            get
            {
                yield return new TestCaseData(new DateTime(2018, 06, 01), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(new DateTime(2018, 07, 02));
                yield return new TestCaseData(new DateTime(2018, 11, 01), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(new DateTime(2018, 12, 03));
                yield return new TestCaseData(new DateTime(2018, 12, 01), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).Returns(new DateTime(2018, 12, 31));
            }
        }
    }
}
