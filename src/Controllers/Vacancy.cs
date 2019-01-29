using System;
using Microsoft.AspNetCore.Mvc;

namespace App.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController
    {
        [HttpGet("{id}")]
        public IActionResult Get(string id)
            => throw new NotImplementedException();

        [HttpPost]
        public IActionResult Add()
            => throw new NotImplementedException();

        [HttpPatch("{id}")]
        public IActionResult Update(string id)
            => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
            => throw new NotImplementedException();
    }
}