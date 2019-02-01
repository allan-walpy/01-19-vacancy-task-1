using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using App.Server.Models.Attributes;

namespace App.Server.Models.Database
{
    [Table(DatabaseContext.VacancyTableName)]
    public class VacancyModel
    {
        [Key]
        [ValidGuidString]
        public string Id { get; set; }

        [Required]
        [ValidVacancyTitle]
        public string Title { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }

        [Required]
        [ValidVacancyDescription]
        public string Description { get; set; }

        [Required]
        public OrganizationModel Organization { get; set; }

        public ICollection<EmploymentType> EmploymentType { get; set; }

        public Person ContactPerson { get; set; }

        [DataType(DataType.PhoneNumber)]
        [ValidPhoneNumber]
        public string ContactPhone { get; set; }

        [Required]
        public long LastUpdated { get; set; }

        [Required]
        public long CreatedAt { get; set; }
    }
}