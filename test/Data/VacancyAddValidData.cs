using System.Collections.Generic;
using Xunit;

using App.Server.Models.Requests;

namespace App.Server.Test.Data
{
    public class VacancyAddValidData : TheoryData<VacancyAddRequest>
    {
        public VacancyAddValidData(IEnumerable<VacancyAddRequest> list)
        {
            foreach(var item in list)
            {
                Add(item);
            }
        }
    }
}