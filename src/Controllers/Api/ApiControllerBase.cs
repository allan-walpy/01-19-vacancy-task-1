using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Walpy.VacancyApp.Server.Models.Responses;

namespace Walpy.VacancyApp.Server.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]/")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public abstract class ApiControllerBase : Controller
    {
        public const string ConsumesType = "application/json";
    }
}