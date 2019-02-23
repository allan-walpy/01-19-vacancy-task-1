using System;

using Walpy.VacancyApp.Server.All.Models.Database;
using Walpy.VacancyApp.Server.All.Services;

namespace Walpy.VacancyApp.Server.All.Models.Services
{
    public class OrganizationFilter : SearchFilterBase<OrganizationFilterOptions>
    {
        protected IDatabaseOrganizationService OrganizationService { get; }
        protected string Id { get; }

        public OrganizationFilter(
            OrganizationFilterOptions options,
            IDatabaseOrganizationService organizationService)
            : base(options)
        {
            OrganizationService = organizationService;
            Id = GetId();
        }

        protected string GetId()
        {
            if (Options.Id != null)
            {
                return Options.Id;
            }

            return OrganizationService.GetByName(Options.Name)?.Id
                ?? Guid.Empty.ToString();
        }

        protected override bool Check(VacancyModel vacancy)
            => vacancy.OrganizationId == Id;
    }
}