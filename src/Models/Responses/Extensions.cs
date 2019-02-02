using System;
using System.Linq;

using App.Server.Models.Database;
using App.Server.Services;

namespace App.Server.Models.Responses
{
    public static class Extensions
    {
        public static OrganizationResponse ToResponse(this OrganizationModel model)
            => new OrganizationResponse
            {
                Id = model.Id,
                Name = model.Name
            };

        public static VacancyResponse ToResponse(
            this VacancyModel model,
            IDatabaseOrganizationService organizationService)
            => new VacancyResponse
            {
                Id = model.Id,
                Title = model.Title,
                Salary = model.Salary,
                Description = model.Description,
                Organization = organizationService.Get(model.OrganizationId).ToResponse(),
                EmploymentType = model.EmploymentType?.ToList()
                    ?.ConvertAll((item) => Enum.GetName(typeof(EmploymentType), item)),
                ContactPerson = model.ContactPerson,
                ContactPhone = model.ContactPhone,
                LastUpdated = model.LastUpdated,
                CreatedAt = model.CreatedAt
            };
    }
}