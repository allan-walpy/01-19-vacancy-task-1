using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using App.Server.Models.Attributes;

namespace App.Server.Models.Requests
{
    public class VacancyAddRequest
    {
        [Required]
        [ValidVacancyTitle]
        public string Title { get; set; }

        [ValidSalary]
        public decimal? Salary { get; set; }

        [Required]
        [ValidVacancyDescription]
        public string Description { get; set; }

        [Required]
        [ValidOrganizationName]
        public string Organization { get; set; }

        [Required]
        [ValidEnumList(typeof(EmploymentType))]
        public List<string> EmploymentType { get; set; }

        public Person ContactPerson { get; set; }

        [ValidPhoneNumber]
        public string ContactPhone { get; set; }
    }
}