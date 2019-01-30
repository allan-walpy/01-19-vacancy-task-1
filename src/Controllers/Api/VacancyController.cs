using System;
using Microsoft.AspNetCore.Mvc;

namespace App.Server.Controllers.Api
{
    public class VacancyController : ApiControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(string id)
            => throw new NotImplementedException();

        [HttpGet("{id}")]
        public IActionResult Get(string id)
            => throw new NotImplementedException();

        [HttpPost]
        public IActionResult Add([FromBody] object vacancy)
            => throw new NotImplementedException();

        [HttpPatch("{id}")]
        public IActionResult Update(string id)
            => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
            => throw new NotImplementedException();
    }
}