using App.Server.Models.Attributes;

namespace App.Server.Models.Requests
{
    [AnyNotNull(nameof(Salary), nameof(Organization), nameof(KeyWords))]
    public class SearchRequest
    {
        public SalaryFilterModel Salary { get; set; }

        public OrganizationFilterModel Organization { get; set; }

        public KeyWordsFilterModel KeyWords { get; set; }
    }
}