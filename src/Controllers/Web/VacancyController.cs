using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using App.Server.Services;
using App.Server.Models.Responses;
using App.Server.Models.Web;

namespace App.Server.Controllers.Web
{
    public class VacancyController : WebController
    {
        private VacancyControllerService VacancyService { get; }
        private IDatabaseOrganizationService OrganizationService { get; }

        public VacancyController(
            IConfiguration configuration,
            VacancyControllerService vacancyService,
            IDatabaseOrganizationService organizationService)
            : base (configuration)
        {
            VacancyService = vacancyService;
            OrganizationService = organizationService;
        }

        public IActionResult Index()
            => View(VacancyService.Get().ConvertAll((v) => v.ToResponse(OrganizationService)));

        [ActionName("View")]
        [HttpGet("{id}")]
        public IActionResult ViewAction([FromRoute] string id)
            => View();

        public IActionResult Create()
            => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] VacancyCreateModel vacancyData)
        {
            if (!ModelState.IsValid)
            {
                return View(vacancyData);
            }

            var id = VacancyService.Add(vacancyData.ToModel(OrganizationService));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public IActionResult Edit()
            => View();

        [HttpGet("{id}")]
        public IActionResult Delete()
            => View();
    }
}