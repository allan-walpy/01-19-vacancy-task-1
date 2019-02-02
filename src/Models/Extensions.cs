using System;
using System.Collections.Generic;

namespace App.Server.Models
{
    public static class Extensions
    {
        public static EmploymentType ToEmploymentType(this string value)
            => Enum.Parse<EmploymentType>(value);

        public static List<EmploymentType> ToEmploymentType(this List<string> list)
            => list?.ConvertAll(ToEmploymentType);
    }
}