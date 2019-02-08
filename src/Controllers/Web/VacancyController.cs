using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using App.Server.Services;
using App.Server.Models.Database;
using App.Server.Models.Responses;
using App.Server.Models.Requests;
using App.Server.Models.Web;
using App.Server.Models.Web.Vacancy;

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

        private ICollection<VacancyResponse> GetAllVacancies()
            => VacancyService.Get().ConvertAll((v) => v.ToResponse(OrganizationService));

        private IndexDataModel GetDefaultIndexDataModel()
            => new IndexDataModel
            {
                Data = GetAllVacancies()
            };

        public IActionResult Index()
            => View(GetDefaultIndexDataModel());

        [HttpPost]
        public IActionResult Index([Bind] IndexPageState pageState)
        {
            var model = GetDefaultIndexDataModel();
            model.State = pageState;
            return View(model);
        }

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

            var model = GetDefaultIndexDataModel();
            model.State = new IndexPageState
            {
                IsSuccess = true,
                Message = "Вакансия создана успешно"
            };
            return RedirectToAction(nameof(Index), model);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(string id)
        {
            var model = VacancyService.Get(id);
            return View(model);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] VacancyResponse vacancyData)
        {
            if (!ModelState.IsValid)
            {
                return View(vacancyData);
            }

            var storedModel = VacancyService.Get(vacancyData.Id);
            var updateRequest = storedModel.ToUpdateCommandBy(vacancyData);

            var updated = VacancyService.Update(vacancyData.Id, updateRequest);
            var expectedUpdated = vacancyData.ToModel();

            var success = updated.IsIdenticTo(expectedUpdated);

            var successDependMessage = (success ? "Вакансия обновлена успешно" : "Не все поля были обновленны должнвм образом");
            var updatedFields = updateRequest.GetUpdatedFieldsList();
            var updatedFieldsMessage = String.Join(
                ", ",
                updatedFields
            );

            var model = GetDefaultIndexDataModel();
            model.State = new IndexPageState
            {
                IsSuccess = success,
                Message = $"{successDependMessage}. {(updatedFields.Count > 0 ? $"Данные поля изменены: {updatedFieldsMessage}" : "Ни одно поле не ищменено")}"
            };
            return RedirectToAction(nameof(Index), model);
        }

        [HttpGet("{id}")]
        public IActionResult Delete(string id)
        {
            var model = VacancyService.Get(id);
            return View(model);
        }

        [HttpPost("{id}")]
        [ActionName("Delete")]
        public IActionResult DeleteComfirmed([Bind] string id)
        {
            var success = VacancyService.Delete(id);
            var model = GetDefaultIndexDataModel();

            model.State = new IndexPageState
            {
                IsSuccess = success,
                Message = success ? "Вакансия успешно удалена" : "Что-то пошло не так при удалении вакансии"
            };
            return RedirectToAction(nameof(Index), model);
        }
    }
}