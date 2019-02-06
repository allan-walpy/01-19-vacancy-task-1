using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace App.Server.Controllers.Web
{
    //? hides razor from api explorer;
    //? + swagger/openapi ignores controllers;
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("web/[controller]/[action]")]
    public abstract class WebController : Controller
    {
        public IConfiguration Configuration { get; }

        protected WebController(IConfiguration config)
        {
            Configuration = config;
        }
    }
}