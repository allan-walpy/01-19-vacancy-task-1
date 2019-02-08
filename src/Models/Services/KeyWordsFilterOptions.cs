namespace Walpy.VacancyApp.Server.Models.Services
{
    public class KeyWordsFilterOptions
    {
        public string SearchString { get; set; }

        public KeyWordsFilter.SearchStringMatch Match { get; set; }

        public KeyWordsFilter.SearchStringScope Scope { get; set; }
    }
}