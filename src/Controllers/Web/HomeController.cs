using Microsoft.AspNetCore.Mvc;

namespace App.Server.Controllers.Web
{
    public class HomeController : WebController
    {
        public ActionResult Index()
        {
            return View("some");
        }

        public ActionResult Help()
        {
            return View("Help");
        }
    }
}