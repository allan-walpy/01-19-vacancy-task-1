using System;
using System.Collections.Generic;
using System.Linq;

using Walpy.VacancyApp.Server.Models.Database;
using Walpy.VacancyApp.Server.Services;

namespace Walpy.VacancyApp.Server.Models.Services
{
    public class SearchFilter : SearchFilterBase<SearchFilterOptions>
    {
        protected List<Func<VacancyModel, bool>> Predicates { get; }

        public SearchFilter(
            SearchFilterOptions options,
            IDatabaseOrganizationService organizationService)
            : base(options)
        {
            Predicates = GetPredicates(organizationService);
        }

        protected List<Func<VacancyModel, bool>> GetPredicates(
            IDatabaseOrganizationService organizationService)
        {
            var predicates = new List<Func<VacancyModel, bool>>();

            if (Options.SalaryOptions != null)
            {
                predicates.Add(new SalaryFilter(Options.SalaryOptions)
                    .GetPredicate());
            }

            if (Options.OrganizationOptions != null)
            {
                predicates.Add(new OrganizationFilter(Options.OrganizationOptions, organizationService)
                    .GetPredicate());
            }

            if (Options.KeyWordsOptions != null)
            {
                predicates.Add(new KeyWordsFilter(Options.KeyWordsOptions)
                    .GetPredicate());
            }

            return predicates;
        }

        protected override bool Check(VacancyModel vacancy)
            => Predicates.All((predicate) => predicate(vacancy));
    }
}