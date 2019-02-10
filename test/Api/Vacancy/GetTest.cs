using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Xunit;

using Walpy.VacancyApp.Server.Models.Responses;
using Walpy.VacancyApp.Server.Test.Models;
using Walpy.VacancyApp.Server.Test.Data;

namespace Walpy.VacancyApp.Server.Test.Api.Vacancy
{
    public partial class GetTest : VacancyTestBase
    {
        public static BaseTheoryData<int, object> DatabaseItemsId
            => new BaseTheoryData<int, object>(
                Enumerable.Range(0, Common.GetTestsCount()));

        public override HttpMethod Method => HttpMethod.Get;

        public GetTest()
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
            Assert.NotNull(actual.Title);
            Assert.NotNull(actual.Organization);
            Assert.NotNull(actual.Description);
            Assert.NotNull(actual.EmploymentType);
        }

        [Theory]
        [MemberData(nameof(DatabaseItemsId))]
        public void Valid200(int id)
        {
            var expected = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = StatusCodes.Status200OK,
                Headers = null,
                Data = null,
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

            AssertValidResponseByRequest<VacancyResponse>(request, expected, DatabaseGuids[id]);
        }
    }
}