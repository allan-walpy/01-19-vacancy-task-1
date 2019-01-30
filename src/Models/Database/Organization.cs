using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Server.Models.Database
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Vacancy> Vacancy { get; set; }
        [ForeignKey("Vacancy")]
        public List<string> VacancyId { get; set; }
    }
}