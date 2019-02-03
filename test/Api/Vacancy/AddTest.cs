using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Xunit;

using App.Server.Models.Responses;
using App.Server.Models.Requests;
using App.Server.Test.Data;
using App.Server.Test.Models;

namespace App.Server.Test.Api.Vacancy
{
    public class AddTest : VacancyTestBase
    {
        public override HttpMethod Method => HttpMethod.Post;

        public static VacancyAddValidData ValidInputData
            => new VacancyAddValidData(
                new List<VacancyAddRequest>
                {
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net (Junior .Net Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "FullTime" }
                    }
                }
            );

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
        [MemberData(nameof(ValidInputData))]
        public void ValidInput(VacancyAddRequest requestModel)
        {
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
                Data = requestModel,
                BadModel = null
            };
            AssertResponseByRequest<VacancyAddResponse>(request, expected);
        }
    }
}