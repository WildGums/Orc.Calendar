﻿[assembly: System.Resources.NeutralResourcesLanguage("en-US")]
[assembly: System.Runtime.InteropServices.ComVisible(false)]
[assembly: System.Runtime.Versioning.TargetFramework(".NETCoreApp,Version=v6.0", FrameworkDisplayName="")]
public static class ModuleInitializer
{
    public static void Initialize() { }
}
namespace Orc.Calendar
{
    public static class DateTimeExtensions
    {
        public static int CalculateNoOfWeeks(this System.DateTime startDate, System.DateTime endDate) { }
        public static int CalculateNoOfWeeks(this System.DateTime? startDate, System.DateTime? endDate) { }
        public static System.DateTime GetFirstDayOfMonth(this System.DateTime time, System.Globalization.CalendarWeekRule calendarWeekRule, System.DayOfWeek dayOfWeek) { }
        public static System.DateTime GetFirstDayOfNextMonth(this System.DateTime time, System.Globalization.CalendarWeekRule calendarWeekRule, System.DayOfWeek dayOfWeek) { }
        public static System.DateTime GetFirstMondayOfMonth(this System.DateTime time, System.Globalization.CalendarWeekRule calendarWeekRule) { }
        public static System.DateTime GetFirstMondayOfNextMonth(this System.DateTime time, System.Globalization.CalendarWeekRule calendarWeekRule) { }
        public static System.DateTime GetMaximum(this System.DateTime a, System.DateTime b) { }
        public static System.DateTime GetMaximum(this System.DateTime a, System.DateTime? b) { }
        public static System.DateTime GetMinimum(this System.DateTime a, System.DateTime b) { }
        public static System.DateTime GetMinimum(this System.DateTime a, System.DateTime? b) { }
        public static int GetWeekOfMonth(this System.DateTime dt, System.Globalization.CalendarWeekRule calendarWeekRule, System.DayOfWeek firstDayOfWeek) { }
        public static int GetWeekOfYear(this System.DateTime dt, System.Globalization.CalendarWeekRule calendarWeekRule, System.DayOfWeek firstDayOfWeek) { }
    }
}