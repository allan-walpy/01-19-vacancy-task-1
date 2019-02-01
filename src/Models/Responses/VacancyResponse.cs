using System.Collections.Generic;

namespace App.Server.Models.Responses
{
    public class VacancyResponse
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public decimal? Salary { get; set; }

        public string Description { get; set; }

        public OrganizationResponse Organization { get; set; }

        public ICollection<string> EmploymentType { get; set; }

        public Person ContactPerson { get; set; }

        public string ContactPhone { get; set; }

        public long LastUpdated { get; set; }

        public long CreatedAt { get; set; }
    }
}