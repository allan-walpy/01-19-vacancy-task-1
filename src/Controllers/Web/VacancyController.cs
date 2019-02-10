using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Walpy.VacancyApp.Server.Services;
using Walpy.VacancyApp.Server.Models.Database;
using Walpy.VacancyApp.Server.Models.Responses;
using Walpy.VacancyApp.Server.Models.Requests;
using Walpy.VacancyApp.Server.Models.Web;
using Walpy.VacancyApp.Server.Models.Web.Vacancy;

namespace Walpy.VacancyApp.Server.Controllers.Web
{
    public partial class VacancyController : WebControllerBase
    {
        private VacancyControllerService VacancyService { get; }
        private IDatabaseOrganizationService OrganizationService { get; }

        public VacancyController(
            IConfiguration configuration,
            VacancyControllerService vacancyService,
            IDatabaseOrganizationService organizationService)
            : base(configuration)
        {
            VacancyService = vacancyService;
            OrganizationService = organizationService;
        }

        private ICollection<VacancyResponse> GetAllVacancies()
            => VacancyService.Get().ConvertAll((v) => v.ToResponse(OrganizationService));

        private VacancyResponse GetVacancy(string id)
            => VacancyService.Get(id)?.ToResponse(OrganizationService);

        private IndexPageStatusModel GetNotFoundStatusModel(string id)
            => new IndexPageStatusModel
            {
                StatusId = NotFoundStatusDataKey,
                VacancyId = id
            };

        public IActionResult Index([Bind] IndexPageStatusModel pageStatusModel = null)
        {
            var dataModel = new IndexDataModel
            {
                Data = GetAllVacancies(),
                Status = pageStatusModel.ToStatus(PageStatusData)
            };

            return View(dataModel);
        }

        [ActionName("View")]
        [HttpGet("{id}")]
        public IActionResult ViewAction([FromRoute] string id)
        {
            var vacancyData = GetVacancy(id);
            if (vacancyData == null)
            {
                return RedirectToAction(nameof(Index), GetNotFoundStatusModel(id));
            }

            return View(vacancyData);
        }

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
            var success = id != null && id != Guid.Empty.ToString();

            var model = new IndexPageStatusModel
            {
                StatusId = $"{nameof(Create)}:{success}",
                VacancyId = id
            };

            return RedirectToAction(nameof(Index), model);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(string id)
        {
            var vacancyData = GetVacancy(id);
            if (vacancyData == null)
            {
                return RedirectToAction(nameof(Index), GetNotFoundStatusModel(id));
            }

            return View(vacancyData);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] VacancyResponse vacancyData)
        {
            if (!ModelState.IsValid)
            {
                var vacancy = VacancyService.Get(vacancyData.Id);
                //TODO:FIXME:;
                vacancyData.Organization = OrganizationService.Get(vacancy.OrganizationId).ToResponse();
                return View(vacancyData);
            }

            var storedModel = VacancyService.Get(vacancyData.Id);
            var updateRequest = storedModel.ToUpdateCommandBy(vacancyData);

            var updated = VacancyService.Update(vacancyData.Id, updateRequest);

            var expectedUpdated = vacancyData.ToModel();
            var success = updated.IsIdenticTo(expectedUpdated);

            var model = new IndexPageStatusModel
            {
                StatusId = $"{nameof(Edit)}:{success}",
                VacancyId = vacancyData.Id
            };
            return RedirectToAction(nameof(Index), model);
        }

        [HttpGet("{id}")]
        public IActionResult Delete(string id)
        {
            var vacancyData = GetVacancy(id);
            if (vacancyData == null)
            {
                return RedirectToAction(nameof(Index), GetNotFoundStatusModel(id));
            }

            return View(vacancyData);
        }

        [HttpPost("{id}")]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteComfirmed([Bind] string id)
        {
            var success = VacancyService.Delete(id);

            var model = new IndexPageStatusModel
            {
                StatusId = $"{nameof(Edit)}:{success}",
                VacancyId = id
            };
            return RedirectToAction(nameof(Index), model);
        }
    }
}