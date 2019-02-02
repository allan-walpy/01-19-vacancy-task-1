using System;

using App.Server.Models.Requests;

namespace App.Server.Models.Services
{
    public static class Extensions
    {
        public static SalaryFilterOptions FromModel(this SalaryFilterModel model)
            => new SalaryFilterOptions
            {
                Max = model.Max,
                Min = model.Min
            };

        public static OrganizationFilterOptions FromModel(this OrganizationFilterModel model)
            => new OrganizationFilterOptions
            {
                Id = model.Id,
                Name = model.Name
            };

        public static KeyWordsFilterOptions FromModel(this KeyWordsFilterModel model)
            => new KeyWordsFilterOptions
            {
                SearchString = model.SearchString,
                Match = Enum.Parse<KeyWordsFilter.SearchStringMatch>(model.Match),
                Scope = Enum.Parse<KeyWordsFilter.SearchStringScope>(model.Scope)
            };

        public static SearchFilterOptions FromRequest(this SearchRequest request)
            => new SearchFilterOptions
            {
                SalaryOptions = request.Salary.FromModel(),
                OrganizationOptions = request.Organization.FromModel(),
                KeyWordsOptions = request.KeyWords.FromModel()
            }
    }
}