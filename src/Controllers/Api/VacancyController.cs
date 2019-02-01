using Microsoft.AspNetCore.Mvc;

using App.Server.Models.Database;
using App.Server.Services;

namespace App.Server.Controllers.Api
{
    public class VacancyController : ApiControllerBase
    {
        private VacancyControllerService Service { get; }

        public VacancyController(VacancyControllerService serivce)
        {
            Service = serivce;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var vacancy = Service.Get(id);
            if (vacancy == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(vacancy);
        }

        [HttpPost]
        public IActionResult Add([FromBody] VacancyModel vacancy)
        {
            var id = Service.Add(vacancy);
            if (id == null)
            {
                return new ConflictResult();
            }

            return new OkObjectResult(id);
        }

        [HttpPatch("{id}")]
        public IActionResult Update(string id, VacancyUpdateModel update)
        {
            var vacancy = Service.Get(id);
            if (vacancy == null)
            {
                return new NotFoundResult();
            }

            var updatedVacancy = Service.Update(id, update);
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
            var exists = Service.Exists(id);
            if (!exists)
            {
                return new NotFoundResult();
            }

            var success = Service.Delete(id);
            if (!success)
            {
                return new ConflictResult();
            }

            return new OkResult();
        }
    }
}