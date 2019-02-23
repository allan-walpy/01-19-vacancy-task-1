using System;
using System.Collections.Generic;

using Walpy.VacancyApp.Server.Core.Database;

namespace Walpy.VacancyApp.Server.All.Services
{
    public interface IDatabaseVacancyService
        : IDatabaseTableService<VacancyModel, string>
    {
        List<VacancyModel> GetRangeBy(Func<VacancyModel, bool> predicate);

        VacancyModel Update(string id, VacancyUpdateModel updateRequest);
    }
}