using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Const = App.Server.Constants.Database;

namespace App.Server.Models.Database
{
    [Table(Const.OrganizationTableName)]
    public class OrganizationModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<VacancyModel> Vacancy { get; set; }
    }
}