using System.Collections.Generic;

namespace App.Server.Models.Database
{
    public class VacancyUpdateModel
    {

        public UpdateCommandModel<string> Title { get; set; }

        public UpdateCommandModel<string> Description { get; set; }

        public UpdateCommandModel<ICollection<EmploymentType>> EmploymentType { get; set; }

        public UpdateCommandModel<decimal?> Salary { get; set; }

        public UpdateCommandModel<Person> ContactPerson { get; set; }

        public UpdateCommandModel<string> ContactPhone { get; set; }
    }
}