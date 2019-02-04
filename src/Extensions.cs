using System.Text.RegularExpressions;

namespace App.Server
{
    public static partial class Extensions
    {
        public static bool IsValidByRegexPattern(this string value, string pattern)
            => (new Regex(pattern)).IsMatch(value);
    }
}