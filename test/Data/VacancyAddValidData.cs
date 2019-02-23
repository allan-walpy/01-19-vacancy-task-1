using System.Collections.Generic;

using Walpy.VacancyApp.Server.All.Models.Requests;

namespace Walpy.VacancyApp.Test.Data
{
    public class VacancyAddValidData : BaseTheoryData<string, VacancyAddRequest>
    {
        public VacancyAddValidData(IDictionary<string, VacancyAddRequest> list)
            : base(list)
        { }
    }
}