using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Const = App.Server.Constants.Database;

namespace App.Server.Models.Database
{
    [Table(Const.VacancyTableName)]
    public class VacancyModel
    {
        [Key]
        [MaxLength(64)]
        public string Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        [Required]
        [MaxLength(4096)]
        public string Description { get; set; }

        [Required]
        public OrganizationModel Organization { get; set; }
        [ForeignKey(Const.OrganizationTableName)]
        public int OrganizationId { get; set; }

        public EmploymentType[] EmploymentType { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }

        [MaxLength(256)]
        public Person ContactPerson { get; set; }

        [MaxLength(20)]
        [MinLength(11)]
        [DataType(DataType.PhoneNumber)]
        public string ContactPhone { get; set; }

        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public long LastUpdated { get; set; }
    }
}