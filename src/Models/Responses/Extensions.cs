using System.Linq;

using App.Server.Models.Database;
using App.Server.Services;

namespace App.Server.Models.Responses
{
    public static class Extensions
    {
        public static VacancyResponse ToResponse(
            this VacancyModel model,
            IDatabaseOrganizationService organizationService)
            => new VacancyResponse
            {
                Id = model.Id,
                Title = model.Title,
                Salary = model.Salary,
                Description = model.Description,
                Organization = organizationService.Get(model.OrganizationId),
                EmploymentType = model.EmploymentType.ToList()
                    .ConvertAll((item) => item.ToString()),
                ContactPerson = model.ContactPerson,
                ContactPhone = model.ContactPhone,
                LastUpdated = model.LastUpdated
            };
    }
}