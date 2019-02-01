using System;

namespace App.Server.Models.Database
{
    public static class Extensions
    {
        private static void UpdateField<TFieldValue>(
            this VacancyModel vacancy,
            Action<VacancyModel, TFieldValue> parametrUpdateAction,
            UpdateCommandModel<TFieldValue> fieldUpdate)
        {
            if (fieldUpdate.IsModified)
            {
                parametrUpdateAction(vacancy, fieldUpdate.Value);
            }
        }

        public static void Update(this VacancyModel vacancy, VacancyUpdateModel update)
        {
            UpdateField(vacancy, ((item, value) => item.Title = value), update.Title);
            UpdateField(vacancy, ((item, value) => item.Description = value), update.Description);
            UpdateField(vacancy, ((item, value) => item.EmploymentType = value), update.EmploymentType);
            UpdateField(vacancy, ((item, value) => item.Salary = value), update.Salary);
            UpdateField(vacancy, ((item, value) => item.ContactPerson = value), update.ContactPerson);
            UpdateField(vacancy, ((item, value) => item.ContactPhone = value), update.ContactPhone);
        }
    }
}