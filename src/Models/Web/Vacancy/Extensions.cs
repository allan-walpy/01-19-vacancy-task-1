using System;
using System.Collections.Generic;

namespace Walpy.VacancyApp.Server.Models.Web.Vacancy
{
    public static class Extensions
    {
        public static IndexPageStatus ToStatus(
            this IndexPageStatusModel model,
            IReadOnlyDictionary<string, IndexPageStatus> data)
        {
            IndexPageStatus modelData = new IndexPageStatus();
            var success = model?.StatusId != null
                ? data.TryGetValue(model.StatusId, out modelData)
                : false;
            if (!success)
            {
                return null;
            }

            return new IndexPageStatus
            {
                Success = modelData.Success,
                Message = String.Format(modelData.Message, model.VacancyId)
            };
        }
    }
}