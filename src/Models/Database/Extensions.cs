using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using Walpy.VacancyApp.Server.Models.Responses;

namespace Walpy.VacancyApp.Server.Models.Database
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

        public static void Update(this VacancyModel vacancy, VacancyUpdateModel updateRequest)
        {
            UpdateField(vacancy, ((item, value) => item.Title = value), updateRequest.Title);
            UpdateField(vacancy, ((item, value) => item.Description = value), updateRequest.Description);
            UpdateField(vacancy, ((item, value) => item.EmploymentType = value.ToEmploymentType()), updateRequest.EmploymentType);
            UpdateField(vacancy, ((item, value) => item.Salary = value), updateRequest.Salary);
            UpdateField(vacancy, ((item, value) => item.ContactPerson = value), updateRequest.ContactPerson);
            UpdateField(vacancy, ((item, value) => item.ContactPhone = value), updateRequest.ContactPhone);
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

        private static UpdateCommandModel<T> GenerateUpdate<T>(
            T oldValue, T newValue)
        {
            if (oldValue?.Equals(newValue)
                ?? newValue?.Equals(oldValue)
                ?? true)
            {
                return null;
            }

            return new UpdateCommandModel<T>
            {
                IsModified = true,
                Value = newValue
            };
        }

        public static VacancyUpdateModel ToUpdateCommandBy(
            this VacancyModel origin,
            VacancyResponse updated)
        {
            var updateModel = new VacancyUpdateModel();

            updateModel.Title = GenerateUpdate(origin.Title, updated.Title);
            updateModel.Description = GenerateUpdate(origin.Description, updated.Description);
            updateModel.Salary = GenerateUpdate(origin.Salary, updated.Salary);
            updateModel.ContactPerson = GenerateUpdate(origin.ContactPerson, updated.ContactPerson);
            updateModel.ContactPhone = GenerateUpdate(origin.ContactPhone, updated.ContactPhone);
            updateModel.EmploymentType = GenerateUpdate(
                origin.EmploymentType?.ToList()?.ToStringName(),
                updated.EmploymentType?.ToList());

            return updateModel;
        }

        private static void AddIfNotNull<T>(
            this List<string> list,
            UpdateCommandModel<T> updateCommand,
            string fieldName)
        {
            if (updateCommand?.IsModified ?? false)
            {
                list.Add(fieldName);
            }
        }
    }
}