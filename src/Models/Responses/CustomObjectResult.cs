using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Walpy.VacancyApp.Server.Models.Responses
{
    public class CustomObjectResult : ObjectResult
    {
        public CustomObjectResult(object obj, int statusCode = StatusCodes.Status200OK)
            : base(obj)
        {
            StatusCode = statusCode;
        }
    }
}