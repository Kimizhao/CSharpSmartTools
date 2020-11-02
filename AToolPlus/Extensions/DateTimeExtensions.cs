using System;
using System.Collections.Generic;
using System.Text;

namespace AToolPlus.Common
{
    public static class DateTimeExtensions
    {
        public static string ToUTC(this DateTime dt)
        {
            return dt.ToUniversalTime().ToString("yyyyMMddHHmmss");
        }
        public static string ToUTC2(this DateTime dt)
        {
            return dt.AddHours(-8).ToString("yyyyMMddHHmmss");
        }
    }
}
