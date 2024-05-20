using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Utilities
{
    public static class EnumExtension
    {
        public static string GetEnumTitleCase(Enum value)
        {
            return Regex.Replace(value.ToString(), "(\\B[A-Z])", " $1");
        }

        public static string GetEnumLowCase(Enum value)
        {
            return Regex.Replace(value.ToString(), "(\\B[A-Z])", " $1").ToLower();
        }
    }
}
