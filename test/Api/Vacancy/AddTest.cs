using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Xunit;

using App.Server.Models.Responses;
using App.Server.Models.Requests;
using App.Server.Test.Data;
using App.Server.Test.Models;

namespace App.Server.Test.Api.Vacancy
{
    public partial class AddTest : VacancyTestBase
    {
        public static BadModelData TheoryData400
            => new BadModelData(Data400);

        public static VacancyAddValidData TheoryData201
            => new VacancyAddValidData(Data201);

        public override HttpMethod Method => HttpMethod.Post;

        public AddTest()
            : base (new List<VacancyAddRequest>())
        {   }

        protected override void AssertContentAs<T>(T expected, T actual)
        {
            {
                var expectedAs201 = expected as VacancyAddResponse;
                var actualAs201 = actual as VacancyAddResponse;
                AssertContentAs201(expectedAs201, actualAs201);
            }

            {
                var expectedAs400 = expected as BadModelResponse;
                var actualAs400 = actual as BadModelResponse;
                AssertContentAs400(expectedAs400, actualAs400);
            }
        }

        protected void AssertContentAs201(VacancyAddResponse expected, VacancyAddResponse actual)
        {
            if (actual == null && expected == null)
            {
                return;
            }

            Assert.NotNull(actual);
            AssertGuid(actual.Id);
        }

        [Theory]
        [MemberData(nameof(TheoryData201))]
        public void Valid201(string dataKey)
        {
            var data = Data201[dataKey];
            var expected = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = StatusCodes.Status201Created,
                Headers = null,
                Data = new VacancyAddResponse { Id = null },
                BadModel = null
            };

            var request = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = null,
                Headers = null,
                Data = data,
                BadModel = null
            };
            AssertValidResponseByRequest<VacancyAddResponse>(request, expected);
        }

        [Theory]
        [MemberData(nameof(TheoryData400))]
        public void Invalid400(string dataKey)
        {
            var data = Data400[dataKey];
            var expected = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = StatusCodes.Status400BadRequest,
                Headers = null,
                Data = new BadModelResponse
                {
                    Fields = data.InvalidFields?.ToList()
                },
                BadModel = null
            };

            var request = new HttpMessageModel
            {
                ApiCall = null,
                StatusCode = null,
                Headers = null,
                Data = data.RequestData,
                BadModel = null
            };
            Assert400ResponseByRequest(request, expected);
        }
    }
}