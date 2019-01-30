using Microsoft.AspNetCore.Mvc;

namespace App.Server.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class IndexPageRedirectController : Controller
    {
        public ActionResult RedirectIndexPage()
        {
            return RedirectPermanent("/web/");
        }
    }
}