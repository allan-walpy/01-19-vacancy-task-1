using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using App.Server.Models.Web;

namespace App.Server.Controllers.Web
{
    public class HomeController : WebController
    {
        public const string HostConfigKey = "host";
        public const string RedocUiVersionConfigKey = "redocUi";

        public HomeController(IConfiguration configuration)
            : base(configuration)
        { }

        public ActionResult Index()
            => View("Index");

        public ActionResult Help()
            => View("Help", new HelpModel
            {
                Host = Configuration[HostConfigKey],
                RedocUiVersion = Configuration[RedocUiVersionConfigKey]
            });

    }
}