using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;

using App.Server.Test.Models;

namespace App.Server.Test.Api
{
    public abstract class ApiTestBase
    {
        protected abstract HttpMethod Method { get; }
        protected abstract string BasePath { get; }

        protected static ApiClient Client
            => new ApiClient();

        protected ApiTestBase()
        { }

        protected HttpMessageModel SendRequest(
            HttpMessageModel request,
            string additionalApiPath = null)
        {
            request = AddApiPath(request, additionalApiPath);

            var response = Client.Send(request);

            return response.ToModel();
        }

        private HttpMessageModel AddApiPath(HttpMessageModel request, string additionalApiPath = null)
        {
            request.ApiCall = Test.Extensions.UpdateIfNull(request.ApiCall, new ApiCallModel());
            request.ApiCall.Method = Test.Extensions.UpdateIfNull(request.ApiCall.Method, Method);
            request.ApiCall.Path = Test.Extensions.UpdateIfNull(request.ApiCall.Path, new ApiPathModel());
            request.ApiCall.Path.BasePath = Test.Extensions.UpdateIfNull(request.ApiCall.Path.BasePath, BasePath);
            request.ApiCall.Path.AdditionalPath = Test.Extensions.UpdateIfNull(request.ApiCall.Path.AdditionalPath, additionalApiPath ?? String.Empty);
            return request;
        }

        protected void AssertResponses(
            HttpMessageModel request,
            HttpMessageModel expectedResponse,
            string additionalApiPath = null)
        {
            var actualResponse = SendRequest(request, additionalApiPath);
            AssertResponses(expectedResponse, actualResponse);
        }

        protected void AssertResponses<TResponse>(HttpMessageModel expected, HttpMessageModel actual)
            where TResponse : class
        {
            AssertResponsesNoContentCheck(expected, actual);
            AssertContentObjectAs<TResponse>(expected.Data, actual.Data);
        }

        protected void AssertResponsesNoContentCheck(HttpMessageModel expected, HttpMessageModel actual)
        {
            AssertStatusCode(expected.StatusCode, actual.StatusCode);
            AssertHeaders(expected.Headers, actual.Headers);
        }

        protected void AssertStatusCode(int? expected, int? actual)
        {
            if (expected == null)
            {
                return;
            }

            Assert.Equal(expected, actual);
        }

        protected void AssertHeaders(
            Dictionary<string, string[]> expected,
            Dictionary<string, string[]> actual)
        {
            if (expected == null)
            {
                return;
            }

            foreach (var headerExpected in expected)
            {
                var expectedValues = headerExpected.Value.ToList();

                Assert.True(actual.ContainsKey(headerExpected.Key));
                foreach (var valueActual in actual[headerExpected.Key])
                {
                    Assert.True(expectedValues.Contains(valueActual));
                }
            }
        }

        protected void AssertContentObjectAs<T>(object expectedWrap, object actualString)
            where T : class
        {
            var actual = JsonConvert.DeserializeObject<T>(actualString as string);
            var expected = expectedWrap as T;
            AssertContentAs<T>(expected, actual);
        }

        protected abstract void AssertContentAs<T>(T expected, T actual);
    }
}