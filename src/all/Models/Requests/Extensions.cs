using System.Collections.Generic;

using Walpy.VacancyApp.Server.All.Services;
using Walpy.VacancyApp.Server.Core.Attributes;
using Walpy.VacancyApp.Server.Core.Database;
using Walpy.VacancyApp.Server.Core.Types;


namespace Walpy.VacancyApp.Server.All.Models.Requests
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
                EmploymentType = request.EmploymentType?.ToEmploymentType()
                    ?? new List<EmploymentType>()
            };

            var organizationName = request.Organization;
            result.OrganizationId = organizationService.CreateIfAbsent(organizationName);

            return result;
        }

        public static SearchRequest ToNullable(this SearchRequest request)
        {
            if (request == null)
            {
                return null;
            }

            if (request.KeyWords != null
                && request.KeyWords.SearchString == null)
            {
                request.KeyWords = null;
            }

            if (request.Organization != null
                && request.Organization.Id == null
                && request.Organization.Name == null)
            {
                request.Organization = null;
            }

            if (request.Salary != null
                && request.Salary.Min == null
                && request.Salary.Max == null)
            {
                request.Salary = null;
            }

            return request;
        }

        public static bool IsEmpty(this SearchRequest request)
            => request.KeyWords == null
                && request.Salary == null
                && request.Organization == null;
    }
}