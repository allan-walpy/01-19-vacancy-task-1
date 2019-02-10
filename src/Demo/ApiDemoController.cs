namespace Walpy.VacancyApp.Server.Controllers.Api
{
    public class DemoController : ApiControllerBase
    {


/*
        /// <summary>
        /// Возвращает все вакансии, хранящиеся в базе данных
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/vacancy/
        ///
        /// </remarks>
        /// <returns>Все имеющиеся вакансии в убывающем порядке поля <see cref="VacancyResponse.LastUpdated" /></returns>
        /// <response code="200">Success</response>
        /// <response code="500">Unknown Server Error</response>
        [ProducesResponseType(typeof(VacancyGetAllResponse), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            var list = ControllerService.Get()
                .ConvertAll((vacancyModel) => vacancyModel.ToResponse(OrganizationService));
            return new OkObjectResult(
                new VacancyGetAllResponse
                {
                    List = list
                });
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
        [Consumes(ConsumesType)]
        [HttpPost]
        public IActionResult Search([FromBody] SearchRequest request)
            => new OkObjectResult(ControllerService.Search(request));*/
    }
}