using Microsoft.AspNetCore.Mvc;

namespace App.Server.Controllers.Web
{
    //? hides razor from api explorer;
    //? + swagger/openapi ignores controllers;
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("web/[controller]/[action]")]
    public abstract class WebController : Controller
    { }
}