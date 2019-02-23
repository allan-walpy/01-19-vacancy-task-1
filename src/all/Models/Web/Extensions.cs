using Walpy.VacancyApp.Server.All.Services;
using Walpy.VacancyApp.Server.Core.Database;
using Walpy.VacancyApp.Server.Core.Types;

namespace Walpy.VacancyApp.Server.All.Models.Web
{
    public static class Extensions
    {
        public static VacancyModel ToModel(
            this VacancyCreateModel request,
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
            };

            var organizationName = request.Organization;
            result.OrganizationId = organizationService.CreateIfAbsent(organizationName);

            return result;
        }
    }
}