using Microsoft.AspNetCore.Mvc;

namespace App.Server.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]/")]
    public abstract class ApiControllerBase : Controller
    { }
}