using System;
using System.Collections.Generic;

using App.Server.Models.Database;

namespace App.Server.Services
{
    public interface IDatabaseVacancyService
        : IDatabaseTableService<VacancyModel, string>
    {
        List<VacancyModel> GetRangeBy(Func<VacancyModel, bool> predicate);

        VacancyModel Update(string id, VacancyUpdateModel update);
    }
}