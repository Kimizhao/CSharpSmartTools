using System;
using System.Collections.Generic;
using System.Text;

namespace AToolPlus.Common
{
    public static partial class BinaryExtensions
    {
        /// <summary>
        /// 纬度转换
        /// 按度分秒记录，均为2位，高位不足补“0”，
        /// 台站纬度未精确到秒时，秒固定记录为“00”
        /// </summary>
        /// <param name="lat"></param>
        /// <returns></returns>
        public static string ToLat6(this double lat)
        {
            int d = (int)lat;
            int m = (int)((double)(lat-d) * 60);
            int s = (int)((lat * 3600) - (d * 3600) - (m * 60));
            string ss = string.Format("{0}{1}{2}", d.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            return ss;
        }

        /// <summary>
        /// 经度转换
        /// 按度分秒记录，度为3位，分秒均为2位，高位不足补“0”，
        /// 台站经度未精确到秒时，秒固定记录为“00”
        /// </summary>
        /// <param name="lng"></param>
        /// <returns></returns>
        public static string ToLng7(this double lng)
        {
            int d = (int)lng;
            int m = (int)((double)(lng - d) * 60);
            int s = (int)((lng * 3600) - (d * 3600) - (m * 60));
            string ss = string.Format("{0}{1}{2}", d.ToString().PadLeft(3, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            return ss;
        }

        public static double ToLatD(this string lat)
        {
            if (lat == "0")
            {
                return 0.0;
            }

            if (lat.Length != 6)
            {
                lat = lat.PadRight(6, '0');
            }

            int d = Convert.ToInt32(lat.Substring(0,2));
            double m = Convert.ToDouble(lat.Substring(2,2));
            double s = Convert.ToDouble(lat.Substring(4,2));
            double r = d + (double)(m/60) + (double)(s/(60*60));
            return Math.Round(r, 2);
        }

        public static double ToLngD(this string lng)
        {
            if (lng == "0")
            {
                return 0.0;
            }

            if (lng.Length != 7)
            {
                lng = lng.PadRight(7, '0');
            }

            int d = Convert.ToInt32(lng.Substring(0, 3));
            double m = Convert.ToDouble(lng.Substring(3, 2));
            double s = Convert.ToDouble(lng.Substring(5, 2));
            double r = d + (double)(m / 60) + (double)(s / (60 * 60));
            return Math.Round(r, 2);
        }
    }
}
