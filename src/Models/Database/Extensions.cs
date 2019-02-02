using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace App.Server.Models.Database
{
    public static class Extensions
    {
        private static void UpdateField<TFieldValue>(
            this VacancyModel vacancy,
            Action<VacancyModel, TFieldValue> parametrUpdateAction,
            UpdateCommandModel<TFieldValue> fieldUpdate)
        {
            if (fieldUpdate?.IsModified ?? false)
            {
                parametrUpdateAction(vacancy, fieldUpdate.Value);
            }
        }

        public static void Update(this VacancyModel vacancy, VacancyUpdateModel update)
        {
            UpdateField(vacancy, ((item, value) => item.Title = value), update.Title);
            UpdateField(vacancy, ((item, value) => item.Description = value), update.Description);
            UpdateField(vacancy, ((item, value) => item.EmploymentType = value.ToEmploymentType()), update.EmploymentType);
            UpdateField(vacancy, ((item, value) => item.Salary = value), update.Salary);
            UpdateField(vacancy, ((item, value) => item.ContactPerson = value), update.ContactPerson);
            UpdateField(vacancy, ((item, value) => item.ContactPhone = value), update.ContactPhone);
        }

        private static bool IsBothNull<T>(T item1, T item2)
            where T : class
            => (item1 == null) ? item2 == null : false;

        private static bool HasNull<T>(T item1, T item2)
            where T : class
            => item1 == null || item2 == null;

        private static bool IsIdenticPerson(this Person person1, Person person2)
        {
            return IsBothNull(person1, person2)
                || (!HasNull(person1, person2)
                    && person1.Name == person2.Name
                    && person1.Surname == person2.Surname
                    && person1.MiddleName == person2.MiddleName);
        }

        private static bool IsIdenticEmploymentTypes(
            this ICollection<EmploymentType> employmentTypes1,
            ICollection<EmploymentType> employmentTypes2)
        {
            return IsBothNull(employmentTypes1, employmentTypes2)
                || (!HasNull(employmentTypes1, employmentTypes2)
                    && employmentTypes1.Count == employmentTypes2.Count
                    && employmentTypes1.All(employmentTypes2.Contains));
        }

        private static string NormalizePhoneNumber(string phoneNumber)
        {
            const string forbidRegex = "[^0-9]*";
            var regex = new Regex(forbidRegex);
            return regex.Replace(phoneNumber, String.Empty);
        }

        private static bool ComparePhones(string phone1, string phone2)
        {
            if (IsBothNull(phone1, phone2))
            {
                return true;
            }
            else if (HasNull(phone1, phone2))
            {
                return false;
            }

            var rawPhone1 = NormalizePhoneNumber(phone1);
            var rawPhone2 = NormalizePhoneNumber(phone2);
            return rawPhone1 == rawPhone2;
        }

        public static bool IsIdenticTo(
            this VacancyModel vacancy1,
            VacancyModel vacancy2,
            bool isCheckId = false)
        {
            return (isCheckId ? vacancy1.Id == vacancy2.Id : true)
                && vacancy1.Title == vacancy2.Title
                && vacancy1.Salary == vacancy2.Salary
                && vacancy1.Description == vacancy2.Description
                && (vacancy1.ContactPerson.IsIdenticPerson(vacancy2.ContactPerson))
                && (vacancy2.EmploymentType.IsIdenticEmploymentTypes(vacancy2.EmploymentType))
                && ComparePhones(vacancy1.ContactPhone, vacancy2.ContactPhone);
        }
    }
}