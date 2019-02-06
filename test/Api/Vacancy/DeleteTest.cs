using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Xunit;

using App.Server.Models.Responses;
using App.Server.Test.Models;
using App.Server.Test.Data;

namespace App.Server.Test.Api.Vacancy
{
    public partial class DeleteTest : VacancyTestBase
    {
        //? downgrading tests;
        //? see https://github.com/allan-walpy/01-19-vacancy-task-1/issues/24#issuecomment-460981953 ;
        public static BaseTheoryData<int, object> DatabaseItemsId
            => new BaseTheoryData<int, object>(
                Enumerable.Range(0, 2));

        public override HttpMethod Method => HttpMethod.Get;

        public DeleteTest()
            : base(DefaultData.VacancyData)
        { }

        protected override void AssertContentAs<T>(T expected, T actual)
        {
            var guid = expected as string;
            var database = GetItems();
            Assert.DoesNotContain(database, (vacancy) => vacancy.Id == guid);
        }

        [Theory]
        [MemberData(nameof(DatabaseItemsId))]
        public void Valid200(int id)
        {
            var guid = DatabaseGuids[id];

            var expected = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = StatusCodes.Status200OK,
                Headers = null,
                Data = guid,
                BadModel = null
            };

            var request = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = null,
                Headers = null,
                Data = null,
                BadModel = null
            };

            AssertValidResponseByRequest<VacancyResponse>(request, expected, guid);
        }
    }
}