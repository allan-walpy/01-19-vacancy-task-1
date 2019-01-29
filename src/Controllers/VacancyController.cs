using System;
using Microsoft.AspNetCore.Mvc;

namespace App.Server.Controllers
{
    //TODO:FIXME:SUGGESTION get rid of magic strings(?);
    [Route("api/vacancy")]
    [ApiController]
    public class VacancyController
    {
        [HttpGet]
        public IActionResult GetAll()
            => throw new NotImplementedException();

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] string id)
            => throw new NotImplementedException();

        [HttpPost]
        public IActionResult Add([FromBody] object vacancy)
            => throw new NotImplementedException();

        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] string id)
            => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] string id)
            => throw new NotImplementedException();
    }
}