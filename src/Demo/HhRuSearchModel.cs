using System;
using System.Collections.Generic;
using Walpy.VacancyApp.Server.Models.Requests;

namespace Walpy.VacancyApp.Server.Demo
{
    public class HhRuSearchModel
    {
        private Dictionary<string, List<string>> _parameters { get; set; }

        public HhRuSearchModel(SearchRequest request)
        {
            _parameters = new Dictionary<string, List<string>>();
        }

        private void ParseRequest(SearchRequest request)
        {
            _parameters.Add("clusters", new List<string> { "false" });
            _parameters.Add("no_magic", new List<string> { "true" });
            _parameters.Add("only_with_salary", new List<string> { "false" });
            _parameters.Add("order_by", new List<string> { "publication_time" });
            _parameters.Add("area", new List<string> { "43" }); // Kaluga only;

            if (request.KeyWords != null)
            {
                ParseKeyWordFilter(request.KeyWords);
            }



        }

        private void ParseKeyWordFilter(KeyWordsFilterModel keyWordFilter)
        {
            _parameters.Add("text", new List<string> { keyWordFilter.SearchString });

            var fields = new List<string>();
            switch (keyWordFilter.Scope)
            {
                case var value when (value == KeyWordSearchScope.Title || value == KeyWordSearchScope.Both):
                    fields.Add("name");
                    break;

                case KeyWordSearchScope.Description:
                case KeyWordSearchScope.Both:
                    fields.Add("description");
                    break;

                default:
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(keyWordFilter.Scope),
                        actualValue: keyWordFilter.Scope,
                        message: "Unknown Scope Search filter");
            }
            if (fields.Count > 0)
            {
                _parameters.Add("search_field", fields);
            }

            //! Match is not supported;
        }

        private void ParseSalaryFilter(SalaryFilterModel salaryFilter)
        {
            _parameters["only_with_salary"] = new List<string> { "true" };
            _parameters.Add("currency", new List<string> { "RUB" });

            var min = salaryFilter.Min;
            var max = salaryFilter.Max;
            var salary = (min == null) ? max
                : ((max == null) ? min : (min + max) / 2);
            _parameters.Add("salary", new List<string>{ salary.ToString() });
        }

        private void ParseOrganizationFilter(OrganizationFilterModel organizationFilter)
        {

        }
    }
}