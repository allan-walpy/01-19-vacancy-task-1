using System;
using System.Linq;

using App.Server.Models.Attributes;
using App.Server.Models.Database;

using App.Server.Services;

namespace App.Server.Models.Requests
{
    public static class Extensions
    {
        public const int PersonMaxLength = ValidPersonNameAttribute.MaxLength * 6;

        public static EmploymentType ToEmploymentType(this string value)
            => Enum.Parse<EmploymentType>(value);

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
                ContactPerson = new Person
                {
                    Name = request.ContactPersonName,
                    Surname = request.ContactPersonSurname,
                    ThirdName = request.ContactPersonThirdName
                },
                EmploymentType = request.EmploymentType
                    .ConvertAll<EmploymentType>((item) => item.ToEmploymentType())
            };

            var organizationName = request.Organization;
            result.Organization = organizationService.GetByName(organizationName);
            if (result.Organization == null)
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