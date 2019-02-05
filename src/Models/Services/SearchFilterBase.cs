using System;

using App.Server.Models.Database;

namespace App.Server.Models.Services
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