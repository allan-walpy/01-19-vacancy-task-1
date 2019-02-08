using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using App.Server.Models.Web;

namespace App.Server.Controllers.Web
{
    public class HomeController : WebController
    {
        public const string ErrorMessagesConfigKey = "message:error";
        public const string HostConfigKey = "host";
        public const string RedocUiVersionConfigKey = "redocUi";

        public HomeController(IConfiguration configuration)
            : base(configuration)
        { }

        public ActionResult Index()
            => View();

        public ActionResult Help()
        {
            var model = new HelpConfigurationModel
            {
                Host = Configuration[HostConfigKey],
                RedocVersion = Configuration[RedocUiVersionConfigKey]
            };

            return View(model);
        }

        //? thnx to https://codedaze.io/global-error-handling-aspnet-core-mvc/ ;
        [Route("{id}")]
        public ActionResult Error(int id)
        {
            var model = new ErrorModel
            {
                StatusCode = id,
                Error = null,
                Path = null
            };

            var errorFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (errorFeature != null)
            {
                model.Error = errorFeature.Error;
                model.Path = errorFeature.Path;
            }

            model.Message = ErrorGetMessage(model.StatusCode);

            return View(model);
        }

        private string ErrorGetMessage(int statusCode)
        {
            //? C# 8 not supported(?);
            /*return statusCode switch
            {
                int 404 => messages["404"];
                int 409 => messages["409"];
                int 500 => messages["500"];
                _ => throw new NotSupportedOperation();
            };*/

            var messages = Configuration.GetSection(ErrorMessagesConfigKey);
            switch(statusCode)
            {
                case 404:
                    return messages["404"];
                case 409:
                    return messages["409"];
                case 500:
                default:
                    return messages["500"];
            }
        }
    }
}