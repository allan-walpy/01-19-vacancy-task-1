using Microsoft.AspNetCore.Mvc;

namespace App.Server.Controllers.Web
{
    public class HomeController : WebController
    {
        public ActionResult Index()
            => View();

        public ActionResult Help()
            => View();

        public ActionResult Error()
            => View();
    }
}