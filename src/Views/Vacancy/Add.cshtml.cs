using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using App.Server.Services;
using App.Server.Models.Web;

namespace App.Server.Models.Pages
{
    public class VacancyAddPageModel : PageModel
    {
        private IDatabaseOrganizationService OrganizationService { get; }
        private VacancyControllerService VacancyService { get; }

        public VacancyAddPageModel(
            IDatabaseOrganizationService organizationService,
            VacancyControllerService vacancyService)
        {
            OrganizationService = organizationService;
            VacancyService = vacancyService;
        }

        [BindProperty]
        public VacancyAddModel Data { get; set; }
    }
}