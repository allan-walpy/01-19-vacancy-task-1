using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Walpy.VacancyApp.Server.Models.Responses;
using Walpy.VacancyApp.Server.Models.Requests;
using Walpy.VacancyApp.Server.Services;

namespace Walpy.VacancyApp.Server.Controllers.Api
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
        /// <response code="400">Malformed request</response>
        /// <response code="500">Unknown Server Error</response>
        [ProducesResponseType(typeof(SearchResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadModelResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Search([FromBody] SearchRequest request)
            => new OkObjectResult(ControllerService.Search(request));
    }
}