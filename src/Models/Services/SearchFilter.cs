using System;
using System.Collections.Generic;
using System.Linq;

using App.Server.Models.Database;
using App.Server.Services;

namespace App.Server.Models.Services
{
    public abstract class SearchFilter : SearchFilterBase<SearchFilterOptions>
    {
        protected List<Func<VacancyModel, bool>> Predicates { get; }

        public SearchFilter(
            SearchFilterOptions options,
            IDatabaseOrganizationService organizationService)
            : base(options)
        {
            var predicates = new List<Func<VacancyModel, bool>> { };

            predicates.Add(new SalaryFilter(options.SalaryOptions).GetPredicate());
            predicates.Add(new OrganizationFilter(options.OrganizationOptions, organizationService).GetPredicate());
            predicates.Add(new KeyWordsFilter(options.KeyWordsOptions).GetPredicate());
        }

        protected override bool Check(VacancyModel vacancy)
            => Predicates.All((predicate) => predicate(vacancy));
    }
}