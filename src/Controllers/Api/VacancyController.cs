using Microsoft.AspNetCore.Mvc;

using App.Server.Models.Database;
using App.Server.Models.Requests;
using App.Server.Models.Responses;
using App.Server.Services;

namespace App.Server.Controllers.Api
{
    public class VacancyController : ApiControllerBase
    {
        private VacancyControllerService ControllerService { get; }
        private IDatabaseOrganizationService OrganizationService { get; }

        public VacancyController(
            VacancyControllerService controllerSerivce,
            IDatabaseOrganizationService organizationService)
        {
            ControllerService = controllerSerivce;
            OrganizationService = organizationService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var vacancy = ControllerService.Get(id);
            if (vacancy == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(vacancy.ToResponse(OrganizationService));
        }

        [HttpPost]
        public IActionResult Add([FromBody] VacancyAddRequest vacancy)
        {
            var id = ControllerService.Add(vacancy.ToModel(OrganizationService));
            if (id == null)
            {
                return new ConflictResult();
            }

            return new OkObjectResult(id);
        }

        [HttpPatch("{id}")]
        public IActionResult Update(string id, [FromBody] VacancyUpdateModel update)
        {
            var vacancy = ControllerService.Get(id);
            if (vacancy == null)
            {
                return new NotFoundResult();
            }

            var updatedVacancy = ControllerService.Update(id, update);
            vacancy.Update(update);
            bool success = vacancy.IsIdenticTo(updatedVacancy);

            if (!success)
            {
                return new ConflictObjectResult(updatedVacancy);
            }

            return new OkObjectResult(updatedVacancy);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var exists = ControllerService.Exists(id);
            if (!exists)
            {
                return new NotFoundResult();
            }

            var success = ControllerService.Delete(id);
            if (!success)
            {
                return new ConflictResult();
            }

            return new OkResult();
        }
    }
}