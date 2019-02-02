namespace App.Server.Models.Services
{
    public class SearchFilterOptions
    {
        public SalaryFilterOptions SalaryOptions { get; set; }
        public OrganizationFilterOptions OrganizationOptions { get; set; }
        public KeyWordsFilterOptions KeyWordsOptions { get; set; }
    }
}