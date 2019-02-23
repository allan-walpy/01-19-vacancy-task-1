using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace Walpy.VacancyApp.Server.All.Extensions
{
    public static class CommonExtensions
    {
        public const string LicenseSectionConfigKey = "license";
        public const string ContactsSectionConfigKey = "contact";
        public const string OpenApiSectionConfigKey = "openapi";
        public const string OpenApiNameConfigKey = OpenApiSectionConfigKey + ":name";
        public const string OpenApiPathTemplate = "/api/{documentName}.json";

        public static bool IsValidByRegexPattern(this string value, string pattern)
            => (new Regex(pattern)).IsMatch(value);

        public static string GetOpenApiPath(IConfiguration config)
            => OpenApiPathTemplate.Replace("{documentName}", config[OpenApiNameConfigKey]);
    }
}