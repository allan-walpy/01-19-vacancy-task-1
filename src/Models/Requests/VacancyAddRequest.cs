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

        public decimal? Salary { get; set; }

        [Required]
        [ValidVacancyDescription]
        public string Description { get; set; }

        [Required]
        public string Organization { get; set; }

        [Required]
        public List<string> EmploymentType { get; set; }

        [ValidPersonName]
        public string ContactPersonName { get; set; }

        [ValidPersonName]
        public string ContactPersonSurname { get; set; }

        [ValidPersonName]
        public string ContactPersonThirdName { get; set; }

        [ValidPhoneNumber]
        public string ContactPhone { get; set; }
    }
}