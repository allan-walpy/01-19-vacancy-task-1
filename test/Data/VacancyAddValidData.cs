using System.Collections.Generic;

using App.Server.Models.Requests;

namespace App.Server.Test.Data
{
    public class VacancyAddValidData : BaseTheoryData<string, VacancyAddRequest>
    {
        public VacancyAddValidData(IDictionary<string, VacancyAddRequest> list)
            : base(list)
        { }
    }
}