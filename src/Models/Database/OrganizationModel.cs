using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Walpy.VacancyApp.Server.Models.Attributes;

namespace Walpy.VacancyApp.Server.Models.Database
{
    [Table(DatabaseContext.OrganizationTableName)]
    public class OrganizationModel
    {
        [Key]
        [ValidGuidString]
        public string Id { get; set; }

        [Required]
        [ValidOrganizationName]
        public string Name { get; set; }

        public ICollection<VacancyModel> Vacancies { get; set; }
    }
}