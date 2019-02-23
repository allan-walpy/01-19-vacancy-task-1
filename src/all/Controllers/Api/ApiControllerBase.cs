using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Walpy.VacancyApp.Server.All.Models.Responses;

namespace Walpy.VacancyApp.Server.All.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]/")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public abstract class ApiControllerBase : Controller
    {
        public const string ConsumesType = "application/json";
    }
}