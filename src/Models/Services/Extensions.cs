using System;

using Walpy.VacancyApp.Server.Models.Requests;

namespace Walpy.VacancyApp.Server.Models.Services
{
    public static class Extensions
    {
        public static SalaryFilterOptions FromModel(this SalaryFilterModel model)
            => model == null
                ? null
                : new SalaryFilterOptions
                {
                    Max = model.Max,
                    Min = model.Min
                };

        public static OrganizationFilterOptions FromModel(this OrganizationFilterModel model)
            => model == null
                ? null
                : new OrganizationFilterOptions
                {
                    Id = model.Id,
                    Name = model.Name
                };

        public static KeyWordsFilterOptions FromModel(this KeyWordsFilterModel model)
            => model == null
                ? null
                : new KeyWordsFilterOptions
                {
                    SearchString = model.SearchString,
                    Match = model.Match,
                    Scope = model.Scope
                };

        public static SearchFilterOptions FromRequest(this SearchRequest request)
            => new SearchFilterOptions
            {
                SalaryOptions = request.Salary.FromModel(),
                OrganizationOptions = request.Organization.FromModel(),
                KeyWordsOptions = request.KeyWords.FromModel()
            };
    }
}