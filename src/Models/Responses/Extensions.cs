using System.Linq;

using Walpy.VacancyApp.Server.Models.Database;
using Walpy.VacancyApp.Server.Services;

namespace Walpy.VacancyApp.Server.Models.Responses
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
                Organization = ((model.Organization == null)
                    ? organizationService.Get(model.OrganizationId)
                    : model.Organization
                    ).ToResponse(),
                EmploymentType = model.EmploymentType?.ToList()?.ToStringName(),
                ContactPerson = model.ContactPerson,
                ContactPhone = model.ContactPhone,
                LastUpdated = model.LastUpdated,
                CreatedAt = model.CreatedAt
            };

        public static VacancyModel ToModel(this VacancyResponse modelResponse)
            => new VacancyModel
            {
                Id = modelResponse.Id,
                Title = modelResponse.Title,
                Salary = modelResponse.Salary,
                Description = modelResponse.Description,
                OrganizationId = modelResponse.Organization?.Id,
                EmploymentType = modelResponse.EmploymentType?.ToList()?.ToEmploymentType(),
                ContactPerson = modelResponse.ContactPerson,
                ContactPhone = modelResponse.ContactPhone,
                CreatedAt = modelResponse.CreatedAt
            };
    }
}