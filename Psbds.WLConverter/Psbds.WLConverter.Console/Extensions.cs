using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Psbds.WLConverter.Console
{
    public static class Extensions
    {
        public static string SafeSubstring(this string value, int startIndex, int length)
        {
            return new string((value ?? string.Empty).Skip(startIndex).Take(length).ToArray());
        }
    }
}
