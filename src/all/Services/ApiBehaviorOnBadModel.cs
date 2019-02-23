using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using Walpy.VacancyApp.Server.All.Models.Responses;

namespace Walpy.VacancyApp.Server.All.Services
{
    public static class ApiBehaviorOnBadModel
    {
        public static IActionResult OnInvalidModel(ActionContext context)
        {
            var errorDictionary = context.ModelState
                .Where(m => m.Value.ValidationState == ModelValidationState.Invalid)
                .Select(m => new KeyValuePair<string, string[]>(
                    m.Key,
                    m.Value.Errors.ToList().ConvertAll(e => e.ErrorMessage).ToArray()
                ))
                .ToDictionary(x => x.Key, x => x.Value);

            var invalidFields = errorDictionary.Select(e => e.Key).ToList();

            var response = new BadModelResponse
            {
                Errors = errorDictionary,
                Fields = invalidFields
            };
            return new BadRequestObjectResult(response);
        }
    }
}