using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using App.Server.Models.Attributes;

namespace App.Server.Models.Database
{
    [Table(Constants.Database.VacancyTableName)]
    public class VacancyModel
    {
        [Key]
        [ValidGuidString]
        public string Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        [Required]
        [MaxLength(4096)]
        public string Description { get; set; }

        [Required]
        public OrganizationModel Organization { get; set; }

        public ICollection<EmploymentType> EmploymentType { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }

        [MaxLength(256)]
        public Person ContactPerson { get; set; }

        [MaxLength(20)]
        [MinLength(11)]
        [DataType(DataType.PhoneNumber)]
        [ValidPhoneNumber]
        public string ContactPhone { get; set; }

        [Required]
        public long LastUpdated { get; set; }

        [Required]
        public long CreatedAt { get; set; }
    }
}