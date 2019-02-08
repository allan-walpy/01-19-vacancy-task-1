using System.Collections.Generic;
using System.Linq;

using Walpy.VacancyApp.Server.Models.Requests;

namespace Walpy.VacancyApp.Server.Test.Data
{
    public static class DefaultData
    {
        public static List<VacancyAddRequest> VacancyData
            => Walpy.VacancyApp.Server.Test.Api.Vacancy.AddTest.Data201.Values.ToList();
    }
}