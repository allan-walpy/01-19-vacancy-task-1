using System;
using System.Collections.Generic;

using Walpy.VacancyApp.Server.Models.Database;
using Walpy.VacancyApp.Server.Services;

namespace Walpy.VacancyApp.Server.Models
{
    public static class Extensions
    {
        public static EmploymentType ToEmploymentType(this string value)
            => Enum.Parse<EmploymentType>(value, ignoreCase: true);

        public static List<EmploymentType> ToEmploymentType(this List<string> list)
            => list?.ConvertAll(ToEmploymentType);

        public static string ToStringName(this EmploymentType value)
            => Enum.GetName(typeof(EmploymentType), value);

        public static List<string> ToStringName(this List<EmploymentType> employmentTypes)
            => employmentTypes?.ConvertAll<string>(ToStringName);

        public static string GetOrganizationIdByName(
            this IDatabaseOrganizationService organizationService,
            string organizationName)
            => organizationService.GetByName(organizationName)?.Id;

        public static string CreateIfAbsent(
            this IDatabaseOrganizationService organizationService,
            string organizationName)
        {
            var organizationId = organizationService.GetOrganizationIdByName(organizationName);

            if (organizationId == null)
            {
                organizationId = organizationService.Add(
                    new OrganizationModel
                    {
                        Name = organizationName
                    });
            }

            return organizationId;
        }
    }
}