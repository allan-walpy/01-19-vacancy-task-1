using System.Collections.Generic;

using Walpy.VacancyApp.Server.Models.Requests;
using Walpy.VacancyApp.Server.Models.Responses;
using Walpy.VacancyApp.Server.Models.Services;

namespace Walpy.VacancyApp.Server.Services
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
                Result = new List<VacancyResponse>()
            };

            var searchFilter = new SearchFilter(request.FromRequest(), OrganizationService);
            var predicate = searchFilter.GetPredicate();

            var resultList = VacancyService.GetRangeBy(predicate);
            result.Result = resultList.ConvertAll(
                (vacancyModel) => vacancyModel.ToResponse(OrganizationService));

            return result;
        }
    }
}