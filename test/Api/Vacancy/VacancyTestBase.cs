using System.Collections.Generic;

using App.Server.Models.Requests;

namespace App.Server.Test.Api.Vacancy
{
    public abstract class VacancyTestBase : ApiTestBaseWithDatabase
    {
        public override string BasePath => "vacancy";

        protected VacancyTestBase(List<VacancyAddRequest> database)
            : base(database)
        {   }
    }
}