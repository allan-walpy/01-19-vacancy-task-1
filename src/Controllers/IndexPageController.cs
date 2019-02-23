using Microsoft.AspNetCore.Mvc;

namespace Walpy.VacancyApp.Server.Controllers
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