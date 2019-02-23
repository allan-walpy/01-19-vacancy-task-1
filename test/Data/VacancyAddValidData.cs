using System.Collections.Generic;

using Walpy.VacancyApp.Server.Models.Requests;

namespace Walpy.VacancyApp.Server.Test.Data
{
    public class VacancyAddValidData : BaseTheoryData<string, VacancyAddRequest>
    {
        public VacancyAddValidData(IDictionary<string, VacancyAddRequest> list)
            : base(list)
        { }
    }
}