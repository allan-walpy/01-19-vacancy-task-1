using App.Server.Models.Attributes;

namespace App.Server.Models.Requests
{
    [AnyNotNull(nameof(Max), nameof(Min))]
    public class SalaryFilterModel
    {
        [ValidSalary]
        public decimal? Max { get; set; }

        [ValidSalary]
        public decimal? Min { get; set; }
    }
}