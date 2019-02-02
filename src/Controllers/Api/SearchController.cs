using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        [Consumes(ConsumesType)]
        public IActionResult Search([FromBody] SearchRequest request)
            => new OkObjectResult(ControllerService.Search(request));
    }
}