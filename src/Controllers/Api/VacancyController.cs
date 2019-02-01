using System;
using Microsoft.AspNetCore.Mvc;

namespace App.Server.Controllers.Api
{
    public class VacancyController : ApiControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
            //TODO:FIXME:;
            => throw new NotImplementedException();

        [HttpGet("{id}")]
        public IActionResult Get(string id)
            //TODO:FIXME:;
            => throw new NotImplementedException();

        [HttpPost]
        public IActionResult Add([FromBody] object vacancy)
            //TODO:FIXME:;
            => throw new NotImplementedException();

        [HttpPatch("{id}")]
        public IActionResult Update(string id)
            //TODO:FIXME:;
            => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
            //TODO:FIXME:;
            => throw new NotImplementedException();
    }
}