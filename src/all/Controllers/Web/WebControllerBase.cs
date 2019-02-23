using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Walpy.VacancyApp.Server.All.Controllers.Web
{
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