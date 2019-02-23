using System.Collections.Generic;

using Walpy.VacancyApp.Server.Models.Requests;

namespace Walpy.VacancyApp.Server.Test.Api.Vacancy
{
    public abstract class VacancyTestBase : ApiTestBaseWithDatabase
    {
        public override string BasePath => "vacancy";

        protected VacancyTestBase(List<VacancyAddRequest> database)
            : base(database)
        {   }
    }
}