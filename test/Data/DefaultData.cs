using System.Collections.Generic;
using System.Linq;

using App.Server.Models.Requests;

namespace App.Server.Test.Data
{
    public static class DefaultData
    {
        public static List<VacancyAddRequest> VacancyData
            => App.Server.Test.Api.Vacancy.AddTest.Data201.Values.ToList();
    }
}