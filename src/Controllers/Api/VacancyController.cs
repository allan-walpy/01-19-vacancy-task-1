using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using App.Server.Models.Attributes;
using App.Server.Models.Database;
using App.Server.Models.Requests;
using App.Server.Models.Responses;
using App.Server.Services;

namespace App.Server.Controllers.Api
{
    /// <summary>
    /// Vacancies Managent
    /// </summary>
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

        /// <summary>
        /// Returns all stored vacancies
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/vacancy/
        ///
        /// </remarks>
        /// <returns>Vacancy information</returns>
        /// <response code="200">Success</response>
        /// <response code="500">Unknown Server Error</response>
        [ProducesResponseType(typeof(List<VacancyResponse>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
            => new OkObjectResult(ControllerService.Get());

        /// <summary>
        /// Returns vacancy by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/vacancy/40213585-be3b-4ad6-a6f6-e5d1c2e5cb25
        ///
        /// </remarks>
        /// <param name="id">Vacancy Guid</param>
        /// <returns>Vacancy information</returns>
        /// <response code="200">Success</response>
        /// <response code="404">No vacancy with such id</response>
        /// <response code="500">Unknown Server Error</response>
        [ProducesResponseType(typeof(VacancyResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Add new vacancy to database
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/vacancy/
        ///     {
        ///         Title: "Младший разработчик на платформе .Net (Junior .Net Developer)",
        ///         Salary: 15000,
        ///         Description: "Требуется разработчик для создания программы бегущих строк, прям как в матрице",
        ///         Organization: "ООО \"Иновации Каждый День\"",
        ///         EmploymentType: [
        ///             "FullTime",
        ///             "RemoteMethod"
        ///         ],
        ///         ContactPerson: {
        ///             "Name": "Neo"
        ///         },
        ///         ContactPhone: "8 (906) 645-13-27"
        ///     }
        ///
        /// </remarks>
        /// <param name="vacancy">Vacancy info</param>
        /// <returns>id of added vacancy</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Malformed request</response>
        /// <response code="409">Unable to save to database</response>
        /// <response code="500">Unknown Server Error</response>
        [ProducesResponseType(typeof(VacancyResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [Consumes(ConsumesType)]
        [HttpPost]
        public IActionResult Add([FromBody] VacancyAddRequest vacancy)
        {
            var id = ControllerService.Add(vacancy.ToModel(OrganizationService));
            if (id == null)
            {
                return new ConflictResult();
            }

            return new CustomObjectResult(id, StatusCodes.Status201Created);
        }

        /// <summary>
        /// Update existing vacancy
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /api/vacancy/40213585-be3b-4ad6-a6f6-e5d1c2e5cb25
        ///     {
        ///         "Title": {
        ///             "IsModified": true,
        ///             "Value": "Разработчик на платформе .Net (Middle .Net Developer)",
        ///         },
        ///         "Description": {
        ///             "IsModified": true,
        ///             "Value": "Младший разработчик не смог сделать бегущие строки как в матрице: ищем более опытного разработчика"
        ///         },
        ///         "Salary": {
        ///             "IsModified": true,
        ///             "Value": "30000"
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Vacancy Guid</param>
        /// <param name="update">List of changed parametrs and their values</param>
        /// <returns>Updated Vacancy</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Malformed request</response>
        /// <response code="404">No vacancy with such id</response>
        /// <response code="409">Excpected updated vacancy not match with actual</response>
        /// <response code="500">Unknown Server Error</response>
        [ProducesResponseType(typeof(VacancyModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(UpdatesNotMatchResponse), StatusCodes.Status409Conflict)]
        [Consumes(ConsumesType)]
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
                return new ConflictObjectResult(
                    new UpdatesNotMatchResponse
                    {
                        Actual = updatedVacancy,
                        Excpected = vacancy
                    });
            }

            return new OkObjectResult(updatedVacancy);
        }


        /// <summary>
        /// Delete existing vacancy
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/vacancy/40213585-be3b-4ad6-a6f6-e5d1c2e5cb25
        ///
        /// </remarks>
        /// <param name="id">Vacancy Guid</param>
        /// <response code="200">Success</response>
        /// <response code="404">No vacancy with such id</response>
        /// <response code="409">Unable to delete from database</response>
        /// <response code="500">Unknown Server Error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
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