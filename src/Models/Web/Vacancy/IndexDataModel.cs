using System.Collections.Generic;

using Walpy.VacancyApp.Server.Models.Responses;

namespace Walpy.VacancyApp.Server.Models.Web.Vacancy
{
    public class IndexDataModel
    {
        public ICollection<VacancyResponse> Data { get; set; }

        public bool HasStatus => Status != null;
        public IndexPageStatus Status { get; set; }
    }
}