using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using App.Server.Models.Attributes;

namespace App.Server.Models.Database
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

        public ICollection<VacancyModel> Vacancy { get; set; }
    }
}