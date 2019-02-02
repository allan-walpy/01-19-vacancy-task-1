using App.Server.Models.Attributes;
using App.Server.Models.Database;

using App.Server.Services;

namespace App.Server.Models.Requests
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
                EmploymentType = request.EmploymentType
                    .ConvertAll((item) => item.ToEmploymentType())
            };

            var organizationName = request.Organization;
            result.OrganizationId = organizationService.GetByName(organizationName)?.Id;
            if (result.OrganizationId == null)
            {
                result.Organization = new OrganizationModel
                {
                    Name = request.Organization
                };
            }

            return result;
        }
    }
}