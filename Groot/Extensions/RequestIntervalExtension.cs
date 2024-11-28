using System;
using NeoLib.Common.Models;

namespace Groot.Extensions;

public static class RequestIntervalExtension
{
    public static ClosedOpenInterval GetDaysInterval(this DateTime dateTime, int fromOffset, int toOffset)
    {
        var currentDay = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        return new ClosedOpenInterval
        {
            From = currentDay.AddDays(fromOffset), 
            To = currentDay.AddDays(toOffset),
        };
    }
        
    public static ClosedOpenInterval GetHoursInterval(this DateTime dateTime, int fromOffset, int toOffset)
    {
        var currentHour = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0);
        return new ClosedOpenInterval
        {
            From = currentHour.AddHours(fromOffset), 
            To = currentHour.AddHours(toOffset),
        };
    }
        
    public static ClosedOpenInterval GetMinutesInterval(this DateTime dateTime, int fromOffset, int toOffset)
    {
        var currentMinute = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0);
        return new ClosedOpenInterval
        {
            From = currentMinute.AddMinutes(fromOffset), 
            To = currentMinute.AddMinutes(toOffset),
        };
    }
        
    public static ClosedOpenInterval GetSecondsInterval(this DateTime dateTime, int fromOffset, int toOffset)
    {
        var currentSecond = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
        return new ClosedOpenInterval
        {
            From = currentSecond.AddSeconds(fromOffset), 
            To = currentSecond.AddSeconds(toOffset),
        };
    }
}