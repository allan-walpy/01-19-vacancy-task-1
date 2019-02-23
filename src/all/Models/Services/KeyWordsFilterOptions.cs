using Walpy.VacancyApp.Server.All.Models.Requests;

namespace Walpy.VacancyApp.Server.All.Models.Services
{
    public class KeyWordsFilterOptions
    {
        public string SearchString { get; set; }

        public KeyWordSearchMatch Match { get; set; }

        public KeyWordSearchScope Scope { get; set; }
    }
}