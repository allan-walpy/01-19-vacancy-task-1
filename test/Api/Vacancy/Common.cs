using System;
using Walpy.VacancyApp.Server.Test.Data;

namespace Walpy.VacancyApp.Server.Test.Api.Vacancy
{
    public static class Common
    {
        public const string ShortTestEnviroment = "SHORT_TEST";
        public const int DefaultShortCount = 2;
        public static readonly int DefaultFullCount = DefaultData.VacancyData.Count - 1;

        public static int GetTestsCount(
            int fullCount = -1,
            int shortCount = DefaultShortCount)
        {
            var result = (fullCount == -1) ? DefaultFullCount : fullCount;

            var enviromentValue = Environment.GetEnvironmentVariable(ShortTestEnviroment);
            if (enviromentValue == "true")
            {
                result = shortCount;
            }

            return result;
        }
    }
}