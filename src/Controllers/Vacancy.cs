using Microsoft.AspNetCore.Mvc;

namespace App.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController
    {
        [HttpGet]
        public IActionResult Test()
            => new OkObjectResult("Test Call");
    }
}