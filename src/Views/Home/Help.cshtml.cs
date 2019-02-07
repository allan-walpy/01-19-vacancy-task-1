using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

using App.Server.Models.Web;

namespace App.Server.Models.Pages
{
    public class HelpModel : PageModel
    {
        public const string HostConfigKey = "host";
        public const string RedocUiVersionConfigKey = "redocUi";

        [ViewData]
        public HelpConfigurationModel Data { get; set; }

        public HelpModel(IConfiguration configuration)
        {
            Data = new HelpConfigurationModel
            {
                Host = configuration[HostConfigKey],
                RedocVersion = configuration[RedocUiVersionConfigKey]
            };
        }
    }
}