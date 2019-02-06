using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Xunit;

using App.Server.Models;
using App.Server.Models.Database;
using App.Server.Models.Responses;
using App.Server.Test.Models;
using App.Server.Test.Data;

namespace App.Server.Test.Api.Vacancy
{
    public partial class UpdateTest : VacancyTestBase
    {

        //? downgrading tests;
        //? see https://github.com/allan-walpy/01-19-vacancy-task-1/issues/24#issuecomment-460981953 ;
        public const string Letters = "абвгдеёжзи";
        public static BaseTheoryData<int, object> DatabaseItemsId
            => new BaseTheoryData<int, object>(
                Enumerable.Range(0, 2));

        public override HttpMethod Method => HttpMethod.Patch;

        public UpdateTest()
            : base(DefaultData.VacancyData)
        { }

        protected override void AssertContentAs<T>(T expected, T actual)
        {
            var expectedAs200 = expected as VacancyResponse;
            var actualAs200 = actual as VacancyResponse;
            AssertContentAs200(expectedAs200, actualAs200);
        }

        protected void AssertContentAs200(VacancyResponse expected, VacancyResponse actual)
        {
            AssertGuid(actual.Id);
            Assert.Equal(expected.Title, actual.Title);
            Assert.Equal(expected.Description, actual.Description);
            Assert.Equal(expected.Salary, actual.Salary);
            Assert.Equal(expected.ContactPhone, actual.ContactPhone);
            AssertPerson(expected.ContactPerson, actual.ContactPerson);
        }

        protected void AssertPerson(Person expected, Person actual)
        {
            if (expected == null)
            {
                return;
            }

            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Surname, actual.Surname);
            Assert.Equal(expected.MiddleName, actual.MiddleName);
        }

        [Theory]
        [MemberData(nameof(DatabaseItemsId))]
        public void Valid200Title(int id)
        {
            var guid = DatabaseGuids[id];
            var data = DefaultData.VacancyData[id];
            var newTitle = $"newTitle{id}";

            var expected = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = StatusCodes.Status200OK,
                Headers = null,
                Data = new VacancyResponse
                {
                    Id = guid,
                    Title = newTitle,
                    Salary = data.Salary,
                    Description = data.Description,
                    ContactPerson = data.ContactPerson,
                    ContactPhone = data.ContactPhone
                },
                BadModel = null
            };

            var request = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = null,
                Headers = null,
                Data = new VacancyUpdateModel
                {
                    Title = new UpdateCommandModel<string>
                    {
                        IsModified = true,
                        Value = newTitle
                    }
                },
                BadModel = null
            };

            AssertValidResponseByRequest<VacancyResponse>(request, expected, guid);
        }

        [Theory]
        [MemberData(nameof(DatabaseItemsId))]
        public void Valid200Description(int id)
        {
            var guid = DatabaseGuids[id];
            var data = DefaultData.VacancyData[id];
            var newDescription = $"newDescription{id}";

            var expected = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = StatusCodes.Status200OK,
                Headers = null,
                Data = new VacancyResponse
                {
                    Id = guid,
                    Title = data.Title,
                    Salary = data.Salary,
                    Description = newDescription,
                    ContactPerson = data.ContactPerson,
                    ContactPhone = data.ContactPhone
                },
                BadModel = null
            };

            var request = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = null,
                Headers = null,
                Data = new VacancyUpdateModel
                {
                    Description = new UpdateCommandModel<string>
                    {
                        IsModified = true,
                        Value = newDescription
                    }
                },
                BadModel = null
            };

            AssertValidResponseByRequest<VacancyResponse>(request, expected, guid);
        }

        [Theory]
        [MemberData(nameof(DatabaseItemsId))]
        public void Valid200Salary(int id)
        {
            var guid = DatabaseGuids[id];
            var data = DefaultData.VacancyData[id];
            var newSalary = 12000 + id;

            var expected = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = StatusCodes.Status200OK,
                Headers = null,
                Data = new VacancyResponse
                {
                    Id = guid,
                    Title = data.Title,
                    Salary = newSalary,
                    Description = data.Description,
                    ContactPerson = data.ContactPerson,
                    ContactPhone = data.ContactPhone
                },
                BadModel = null
            };

            var request = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = null,
                Headers = null,
                Data = new VacancyUpdateModel
                {
                    Salary = new UpdateCommandModel<decimal?>
                    {
                        IsModified = true,
                        Value = newSalary
                    }
                },
                BadModel = null
            };

            AssertValidResponseByRequest<VacancyResponse>(request, expected, guid);
        }

        [Theory]
        [MemberData(nameof(DatabaseItemsId))]
        public void Valid200ContactPhone(int id)
        {
            var guid = DatabaseGuids[id];
            var data = DefaultData.VacancyData[id];
            var newContactPhone = $"8 (960) 222-33-4{id % 10}";

            var expected = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = StatusCodes.Status200OK,
                Headers = null,
                Data = new VacancyResponse
                {
                    Id = guid,
                    Title = data.Title,
                    Salary = data.Salary,
                    Description = data.Description,
                    ContactPerson = data.ContactPerson,
                    ContactPhone = newContactPhone
                },
                BadModel = null
            };

            var request = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = null,
                Headers = null,
                Data = new VacancyUpdateModel
                {
                    ContactPhone = new UpdateCommandModel<string>
                    {
                        IsModified = true,
                        Value = newContactPhone
                    }
                },
                BadModel = null
            };

            AssertValidResponseByRequest<VacancyResponse>(request, expected, guid);
        }

        [Theory]
        [MemberData(nameof(DatabaseItemsId))]
        public void Valid200ContactPerson(int id)
        {
            var guid = DatabaseGuids[id];
            var data = DefaultData.VacancyData[id];
            var letter = Letters[id % 10];
            var newContactPerson = new Person
            {
                Name = $"newName{letter}",
                Surname = $"newSurname{letter}",
                MiddleName = $"newMiddleName{letter}"
            };

            var expected = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = StatusCodes.Status200OK,
                Headers = null,
                Data = new VacancyResponse
                {
                    Id = guid,
                    Title = data.Title,
                    Salary = data.Salary,
                    Description = data.Description,
                    ContactPerson = newContactPerson,
                    ContactPhone = data.ContactPhone
                },
                BadModel = null
            };

            var request = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = null,
                Headers = null,
                Data = new VacancyUpdateModel
                {
                    ContactPerson = new UpdateCommandModel<Person>
                    {
                        IsModified = true,
                        Value = newContactPerson
                    }
                },
                BadModel = null
            };

            AssertValidResponseByRequest<VacancyResponse>(request, expected, guid);
        }
    }
}