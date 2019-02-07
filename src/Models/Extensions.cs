using System;
using System.Collections.Generic;

using App.Server.Models.Database;
using App.Server.Services;

namespace App.Server.Models
{
    public static class Extensions
    {
        public static EmploymentType ToEmploymentType(this string value)
            => Enum.Parse<EmploymentType>(value, ignoreCase: true);

        public static List<EmploymentType> ToEmploymentType(this List<string> list)
            => list?.ConvertAll(ToEmploymentType);

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