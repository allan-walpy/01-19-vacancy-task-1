using System;
using Microsoft.AspNetCore.Mvc;

using App.Server.Models.Requests;
using App.Server.Models.Responses;

namespace App.Server.Controllers.Api
{
    public class SearchController : ApiControllerBase
    {
        public SearchController()
        { }

        [HttpPost]
        [Consumes(ConsumesType)]
        public IActionResult Search([FromBody] SearchRequest request)
        {
            throw new NotImplementedException();
        }
    }
}