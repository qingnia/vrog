using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateUtil
{
    public static long ConvertTimeStampMilli(DateTime time)
    {
        if (time == null)
        {
            time = DateTime.Now;
        }
        return ((time.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
    }
    public static long ConvertTimeStamp(DateTime time)
    {
        if (time == null)
        {
            time = DateTime.Now;
        }
        return ((time.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
    }
    public static DateTime GetTime(string timeStamp)
    {
        if (timeStamp.Length > 10)
        {
            timeStamp = timeStamp.Substring(0, 10);
        }
        DateTime dateTimeStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
        long lTime = long.Parse(timeStamp + "0000000");
        TimeSpan toNow = new TimeSpan(lTime);
        return dateTimeStart.Add(toNow);
    }
}
