using Microsoft.AspNetCore.Mvc;

namespace App.Server.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]/")]
    [Produces("application/json")]
    //? disabled due to: https://github.com/allan-walpy/01-19-vacancy-task-1/issues/11 ;
    // [Consumes("application/json")]
    public abstract class ApiControllerBase : Controller
    {
        //? tmp workaround, see https://github.com/allan-walpy/01-19-vacancy-task-1/issues/11 ;
        protected const string ConsumesType = "application/json";
    }
}