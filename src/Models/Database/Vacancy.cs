using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Server.Models.Database
{
    public class Vacancy
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        public Salary Salary { get; set; }
        [ForeignKey("Salary")]
        public int SalaryId { get; set; }

        [Required]
        public Organization Organization { get; set; }
        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }

        public Person ContactPerson { get; set; }
        [ForeignKey("Person")]
        public int ContactPersonId { get; set; }

        public Phone ContactPhone { get; set; }
        [ForeignKey("Phone")]
        public int ContactPhoneId { get; set; }

        public List<EmploymentType> EmploymentType { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
    }
}