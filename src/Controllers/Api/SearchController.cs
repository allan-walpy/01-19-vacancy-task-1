using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using App.Server.Models.Responses;
using App.Server.Models.Requests;
using App.Server.Services;

namespace App.Server.Controllers.Api
{
    public class SearchController : ApiControllerBase
    {
        protected SearchControllerService ControllerService { get; set; }
        public SearchController(SearchControllerService controllerService)
        {
            ControllerService = controllerService;
        }

        /// <summary>
        /// Осуществляет поиск по вакансиям
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/search
        ///     {
        ///         "Salary": {
        ///             "Min": 12000
        ///         },
        ///         "Organization": {
        ///             "Name": "ООО \"Иновации Каждый День\""
        ///         },
        ///         "KeyWords": {
        ///             "SearchString": "junior .Net",
        ///             "Match": "AllWords",
        ///             "Scope": "Title"
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <returns>Список вакансий удовлетворяющий запросу в убывающем порядке поля <see cref="VacancyResponse.LastUpdated" /></returns>
        /// <response code="200">Success</response>
        /// <response code="200">Malformed request</response>
        /// <response code="500">Unknown Server Error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(ConsumesType)]
        [HttpPost]
        public IActionResult Search([FromBody] SearchRequest request)
            => new OkObjectResult(ControllerService.Search(request));
    }
}