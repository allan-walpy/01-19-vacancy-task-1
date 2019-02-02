using System.Collections.Generic;

using App.Server.Models.Requests;
using App.Server.Models.Responses;
using App.Server.Models.Services;

namespace App.Server.Services
{
    public sealed class SearchControllerService
    {
        private IDatabaseVacancyService VacancyService { get; }
        private IDatabaseOrganizationService OrganizationService { get; }
        public SearchControllerService(
            IDatabaseVacancyService vacancyService,
            IDatabaseOrganizationService organizationService)
        {
            VacancyService = vacancyService;
            OrganizationService = organizationService;
        }

        public SearchResponse Search(SearchRequest request)
        {
            var result = new SearchResponse
            {
                Result = new List<VacancyResponse> { }
            };

            var searchFilter = new SearchFilter(request.FromRequest(), OrganizationService);
            var predicate = searchFilter.GetPredicate();

            var resultList = VacancyService.GetRangeBy(predicate);
            result.Result = resultList.ConvertAll<VacancyResponse>(
                (vacancyModel) => vacancyModel.ToResponse(OrganizationService));

            return result;
        }
    }
}