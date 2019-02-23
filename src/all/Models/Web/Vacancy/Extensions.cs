using System;
using System.Collections.Generic;

using Walpy.VacancyApp.Server.Core.Attributes;

namespace Walpy.VacancyApp.Server.All.Models.Web.Vacancy
{
    public static class Extensions
    {
        public static IndexPageStatus ToStatus(
            this IndexPageStatusModel model,
            IReadOnlyDictionary<string, IndexPageStatus> data)
        {
            IndexPageStatus modelData = new IndexPageStatus();
            var success = model?.StatusId == null
                ? false
                : data.TryGetValue(model.StatusId.ToLower(), out modelData);
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

        public static string ToViewDateTime(this long timestamp)
        {
            var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).DateTime;
            var date = dateTime.ToLongDateString();
            var time = dateTime.ToLongTimeString();
            return $"{date} {time}";
        }

        public static string ToDisplayName(this string stringEnumValue, Type enumType)
            => enumType.GetField(stringEnumValue).GetDisplayName();
    }
}