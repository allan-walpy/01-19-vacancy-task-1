using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using App.Server.Services;
using App.Server.Models.Web;

namespace App.Server.Controllers.Web
{
    public class VacancyController : WebController
    {
        private VacancyControllerService VacancyService { get; }
        private IDatabaseOrganizationService OrganizationService { get; }

        public VacancyController(
            VacancyControllerService vacancyService,
            IDatabaseOrganizationService organizationService)
        {
            VacancyService = vacancyService;
            OrganizationService = organizationService;
        }

        public IActionResult Index()
            => View("Index");

        [HttpGet]
        public IActionResult Add()
            => View("Add");

        [HttpPost]
        public IActionResult Add(HttpContext context, VacancyAddModel vacancyData)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("Add");
            }

            var id = VacancyService.Add(vacancyData.ToModel(OrganizationService));
            System.Console.WriteLine($"id is {id}");

            return View("Index");
        }
    }
}