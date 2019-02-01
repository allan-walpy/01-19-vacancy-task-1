using System.Collections.Generic;

using App.Server.Models.Attributes;

namespace App.Server.Models.Database
{
    public class VacancyUpdateModel
    {
        [ValidUpdateField(typeof(ValidVacancyTitleAttribute))]
        public UpdateCommandModel<string> Title { get; set; }

        [ValidUpdateField(typeof(ValidVacancyDescriptionAttribute))]
        public UpdateCommandModel<string> Description { get; set; }

        public UpdateCommandModel<List<string>> EmploymentType { get; set; }

        public UpdateCommandModel<decimal?> Salary { get; set; }

        public UpdateCommandModel<Person> ContactPerson { get; set; }

        [ValidUpdateField(typeof(ValidPhoneNumberAttribute))]
        public UpdateCommandModel<string> ContactPhone { get; set; }
    }
}