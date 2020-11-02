using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AToolPlus.Common
{
    public static class StringExtensions
    {
        public static bool IndexIsTrue(this string value, int n, ref int rel)
        {
            if (n < value.Length)
            {
                if (value.Substring(n, 1) == "1")
                {
                    string left = value.Substring(0, n);
                    rel = n - left.CharCount("0");
                    return true;
                }
            }

            return false;
        }

        public static int CharCount(this string value, string s)
        {
            int num = Regex.Matches(value, s).Count;
            return num;
        }
    }
}
