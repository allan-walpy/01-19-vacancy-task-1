using Microsoft.AspNetCore.Mvc;

namespace App.Server.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class IndexPageController : Controller
    {
        public ActionResult Redirect()
        {
            return RedirectPermanent("/web/Home/Index");
        }
    }
}