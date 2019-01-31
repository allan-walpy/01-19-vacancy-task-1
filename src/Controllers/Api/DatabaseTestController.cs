using System;
using Microsoft.AspNetCore.Mvc;

using App.Server.Services;
using App.Server.Models.Database;

namespace App.Server.Controllers.Api
{
    public class DatabaseTestController : ApiControllerBase
    {
        private DatabaseService DbService { get; }
        public DatabaseTestController(DatabaseService dbService)
        {
            DbService = dbService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var vacancy1 = new VacancyModel
            {
                Title = "SomeVacancy1",
                Organization = new OrganizationModel
                {
                    Name = "OOO \"Vacancy Industry\""
                },
                Description = "OOO 'Vacancy Inductry' invite you to SomeVacancy1'"
            };
            //dotnet ef migrations add Initial;
            var result = DbService.Add(vacancy1);
            return new OkObjectResult(result);
        }

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