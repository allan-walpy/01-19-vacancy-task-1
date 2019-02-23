using System;

using Walpy.VacancyApp.Server.All.Models.Database;

namespace Walpy.VacancyApp.Server.All.Models.Services
{
    public abstract class SearchFilterBase<TOptions>
    {
        protected TOptions Options { get; }

        protected SearchFilterBase(TOptions options)
        {
            Options = options;
        }

        public Func<VacancyModel, bool> GetPredicate()
            => Check;

        protected abstract bool Check(VacancyModel vacancy);
    }
}