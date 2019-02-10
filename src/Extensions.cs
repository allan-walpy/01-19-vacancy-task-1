using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace Walpy.VacancyApp.Server
{
    public static partial class Extensions
    {
        public static bool IsValidByRegexPattern(this string value, string pattern)
            => (new Regex(pattern)).IsMatch(value);

        public static string GetOpenApiPath(IConfiguration config)
            => OpenApiPathTemplate.Replace("documentName", config[OpenApiNameConfigKey]);
    }
}