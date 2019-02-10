using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Walpy.VacancyApp.Server.Models.Web;

namespace Walpy.VacancyApp.Server.Controllers.Web
{
    public class HomeController : WebControllerBase
    {
        public const string ErrorMessagesConfigKey = "message:error";
        public const string HostConfigKey = "host";
        public const string RedocUiVersionConfigKey = "redocUi";

        private IConfiguration ErrorMessages { get; }

        public HomeController(IConfiguration configuration)
            : base(configuration)
        {
            ErrorMessages = Configuration.GetSection(ErrorMessagesConfigKey);
        }

        public IActionResult Index()
            => View();

        public IActionResult Help()
        {
            var model = new HelpConfigurationModel
            {
                Host = Configuration[HostConfigKey],
                RedocVersion = Configuration[RedocUiVersionConfigKey],
                OpenApiPath = Extensions.GetOpenApiPath(Configuration)
            };

            return View(model);
        }

        [Route("{id}")]
        public IActionResult Error(int id)
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
            try
            {
                return ErrorMessages[statusCode.ToString()];
            }
            catch (Exception)
            {
                return ErrorMessages["500"];
            }
        }
    }
}