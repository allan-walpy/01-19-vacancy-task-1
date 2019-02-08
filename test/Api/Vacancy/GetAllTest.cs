using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Xunit;

using Walpy.VacancyApp.Server.Models.Responses;
using Walpy.VacancyApp.Server.Test.Models;
using Walpy.VacancyApp.Server.Test.Data;

namespace Walpy.VacancyApp.Server.Test.Api.Vacancy
{
    public partial class GetAllTest : VacancyTestBase
    {
        public override HttpMethod Method => HttpMethod.Get;

        public GetAllTest()
            : base(DefaultData.VacancyData)
        { }

        protected override void AssertContentAs<T>(T expected, T actual)
        {
            var expectedAs200 = expected as VacancyGetAllResponse;
            var actualAs200 = actual as VacancyGetAllResponse;
            AssertContentAs200(expectedAs200, actualAs200);
        }
        protected void AssertContentAs200(VacancyGetAllResponse expected, VacancyGetAllResponse actual)
        {
            Assert.NotNull(actual);
            Assert.Equal(DefaultData.VacancyData.Count, actual.List.Count);
            actual.List.ForEach((vacancy) => {
                AssertGuid(vacancy.Id);
                Assert.NotNull(vacancy.Title);
                Assert.NotNull(vacancy.Organization);
                Assert.NotNull(vacancy.Description);
                Assert.NotNull(vacancy.EmploymentType);
            });
        }

        [Fact]
        public void Valid200()
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

            AssertValidResponseByRequest<VacancyGetAllResponse>(request, expected);
        }
    }
}