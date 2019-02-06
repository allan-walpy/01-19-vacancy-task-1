using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Server.Models.Pages
{
    public class RedocModel : PageModel
    {
        [ViewData]
        public string Host { get; set; }

        [ViewData]
        public string RedocUiVersion { get; set; }
    }
}