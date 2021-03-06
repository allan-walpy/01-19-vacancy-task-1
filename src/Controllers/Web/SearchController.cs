using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Walpy.VacancyApp.Server.Models.Requests;
using Walpy.VacancyApp.Server.Services;

namespace Walpy.VacancyApp.Server.Controllers.Web
{
    public class SearchController : WebControllerBase
    {
        protected SearchControllerService ControllerService { get; set; }
        public SearchController(IConfiguration config, SearchControllerService controllerService)
            : base(config)
        {
            ControllerService = controllerService;
        }

        public IActionResult Index()
            => RedirectToActionPermanent("Request");

        [ActionName("Request")]
        public IActionResult RequestAction()
            => View();

        [HttpPost]
        [ActionName("Request")]
        [ValidateAntiForgeryToken]
        public IActionResult Result([Bind] SearchRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            return View(nameof(Result), ControllerService.Search(request.ToNullable()));
        }
    }
}