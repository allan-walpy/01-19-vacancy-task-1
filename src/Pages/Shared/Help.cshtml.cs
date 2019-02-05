using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Server.Models.Web
{
    public class HelpModel : PageModel
    {
        [ViewData]
        public string Host { get; set; }

        [ViewData]
        public string RedocUiVersion { get; set; }

        public void OnGet()
        { }
    }
}