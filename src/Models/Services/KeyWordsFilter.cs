using System;
using System.Collections.Generic;
using System.Linq;

using Walpy.VacancyApp.Server.Models.Database;
using Walpy.VacancyApp.Server.Models.Requests;

namespace Walpy.VacancyApp.Server.Models.Services
{
    public class KeyWordsFilter : SearchFilterBase<KeyWordsFilterOptions>
    {
        protected List<String> KeyWords { get; }
        protected List<Func<VacancyModel, bool>> CheckMethods { get; }

        public KeyWordsFilter(KeyWordsFilterOptions options)
            : base(options)
        {
            KeyWords = Options.SearchString.Split(' ').ToList();

            var matchMethod = GetMatchMethod();
            var scopeMethods = GetScopeMethods(matchMethod);
            CheckMethods = scopeMethods;
        }

        protected Func<string, bool> GetMatchMethod()
        {
            switch (Options.Match)
            {
                case KeyWordSearchMatch.AllWords:
                    return (item) => KeyWords.All((keyWord) => item.Contains(keyWord));
                case KeyWordSearchMatch.AnyWord:
                    return (item) => KeyWords.Any((keyWord) => item.Contains(keyWord));
                case KeyWordSearchMatch.ExactMatch:
                    return (item) => item.Contains(Options.SearchString);
                default:
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(Options.Match),
                        actualValue: Options.Match,
                        message: "Unknown Search Match Filter"
                    );
            }
        }

        protected List<Func<VacancyModel, bool>> GetScopeMethods(Func<string, bool> matchMethod)
        {
            var result = new List<Func<VacancyModel, bool>>();
            switch (Options.Scope)
            {
                case var value when
                    (value == KeyWordSearchScope.Title || value == KeyWordSearchScope.Both):
                    result.Add(
                        (vacancy) => matchMethod(vacancy.Title)
                    );
                    break;

                case KeyWordSearchScope.Description:
                case KeyWordSearchScope.Both:
                    result.Add(
                            (vacancy) => matchMethod(vacancy.Description)
                        );
                    break;

                default:
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(Options.Scope),
                        actualValue: Options.Scope,
                        message: "Unknown Scope Search filter");
            }

            return result;
        }

        protected override bool Check(VacancyModel vacancy)
            => CheckMethods.All((method) => method(vacancy));
    }
}