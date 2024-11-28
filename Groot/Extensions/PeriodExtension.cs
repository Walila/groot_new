using System;
using System.Globalization;

namespace Groot.Extensions;

public static class PeriodExtension
{
    public static int GetWeekOfYear(this DateTime dateTime, CalendarWeekRule calendarWeekRule)
    {
        var cal = new GregorianCalendar();
        return cal.GetWeekOfYear(dateTime, calendarWeekRule, dateTime.DayOfWeek);
    }
}