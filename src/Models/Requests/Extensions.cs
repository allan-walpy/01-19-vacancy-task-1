using Walpy.VacancyApp.Server.Models.Attributes;
using Walpy.VacancyApp.Server.Models.Database;

using Walpy.VacancyApp.Server.Services;

namespace Walpy.VacancyApp.Server.Models.Requests
{
    public static class Extensions
    {
        public const int PersonMaxLength = ValidPersonNameAttribute.MaxLength * 6;

        public static VacancyModel ToModel(
            this VacancyAddRequest request,
            IDatabaseOrganizationService organizationService)
        {
            var result = new VacancyModel
            {
                Title = request.Title,
                Salary = request.Salary,
                Description = request.Description,
                ContactPhone = request.ContactPhone,
                ContactPerson = request.ContactPerson,
                EmploymentType = request.EmploymentType.ToEmploymentType()
            };

            var organizationName = request.Organization;
            result.OrganizationId = organizationService.CreateIfAbsent(organizationName);

            return result;
        }
    }
}