using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using App.Server.Models.Pages;

namespace App.Server.Controllers.Web
{
    public class HomeController : WebController
    {
        public const string HostConfigKey = "host";
        public const string RedocUiVersionConfigKey = "redocUi";

        public HomeController(IConfiguration config)
            : base(config)
        { }

        public ActionResult Index()
            => View("Index");

        public ActionResult Help()
            => View("Redoc", new RedocModel
            {
                Host = Configuration[HostConfigKey],
                RedocUiVersion = Configuration[RedocUiVersionConfigKey]
            });

        public ActionResult Error()
            => View("Error");

        public ActionResult Eror()
        {
            throw new System.Exception("NO");
        }
    }
}