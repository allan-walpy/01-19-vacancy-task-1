using System.ComponentModel.DataAnnotations;

namespace App.Server.Models.Database
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }

        public string CurrencyCode { get; set; }

        public SalaryRange AmountRange { get; set; }
    }
}