using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Walpy.VacancyApp.Server.Controllers.Web
{
    //? hides razor from api explorer;
    //? + swagger/openapi ignores controllers;
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("web/[controller]/[action]")]
    public abstract class WebControllerBase : Controller
    {
        protected IConfiguration Configuration { get; }

        protected WebControllerBase(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}