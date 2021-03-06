using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Walpy.VacancyApp.Server.Models.Attributes;

namespace Walpy.VacancyApp.Server.Models.Web
{
    public class VacancyCreateModel
    {
        [Required]
        [ValidVacancyTitle]
        [Display(Name = "Название должности")]
        public string Title { get; set; }

        [ValidSalary]
        [Display(Name = "Зарплата")]
        public decimal? Salary { get; set; }

        [Required]
        [ValidVacancyDescription]
        [Display(Name = "Описание должности")]
        public string Description { get; set; }

        [Required]
        [ValidOrganizationName]
        [Display(Name = "Название оргнизации работодателя")]
        public string Organization { get; set; }

        [Display(Name = "Тип занятости")]
        public List<EmploymentType> EmploymentType { get; set; }

        [Display(Name = "Контактное лицо")]
        public Person ContactPerson { get; set; }

        [Display(Name = "Контактный телефон")]
        [ValidPhoneNumber]
        public string ContactPhone { get; set; }
    }
}