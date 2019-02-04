using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;

using App.Server.Models.Responses;
using App.Server.Test.Instance;
using App.Server.Test.Models;

namespace App.Server.Test.Api
{
    public abstract class ApiTestBase : IDisposable
    {
        public const string BaseUrlTemplate = "http://localhost:{0}/api/{1}";

        public abstract HttpMethod Method { get; }
        public abstract string BasePath { get; }

        protected AppInstance App { get; }
        protected ApiClient Client { get; set; }

        protected ApiTestBase()
        {
            App = new AppInstance();
            Client = new ApiClient();
        }

        protected HttpMessageModel SendRequest(
            HttpMessageModel request,
            HttpMethod method,
            string basePath,
            string additionalApiPath = null)
        {
            request = AddApiPath(request, method, basePath, additionalApiPath);
            request = PatchWithPort(request);

            var response = Client.Send(request);

            return response.ToModel();
        }

        protected static HttpMessageModel AddApiPath(
            HttpMessageModel request,
            HttpMethod method,
            string basePath,
            string additionalApiPath = null)
        {
            request.ApiCall = Test.Extensions.UpdateIfNull(request.ApiCall, new ApiCallModel());
            request.ApiCall.Method = Test.Extensions.UpdateIfNull(request.ApiCall.Method, method);
            request.ApiCall.Path = Test.Extensions.UpdateIfNull(request.ApiCall.Path, new ApiPathModel());
            request.ApiCall.Path.BasePath = Test.Extensions.UpdateIfNull(request.ApiCall.Path.BasePath, basePath);
            request.ApiCall.Path.AdditionalPath = Test.Extensions.UpdateIfNull(request.ApiCall.Path.AdditionalPath, additionalApiPath ?? String.Empty);
            return request;
        }

        protected HttpMessageModel PatchWithPort(HttpMessageModel request)
        {
            request.ApiCall.Path.BasePath = String.Format(
                BaseUrlTemplate,
                App.Port,
                request.ApiCall.Path.BasePath
            );
            return request;
        }

        protected void AssertValidResponseByRequest<TResponse>(
            HttpMessageModel request,
            HttpMessageModel expectedResponse,
            string additionalApiPath = null)
            where TResponse : class
        {
            var actualResponse = SendRequest(request, Method, BasePath, additionalApiPath);
            AssertResponsesNoContentCheck(expectedResponse, actualResponse);
            AssertContentObjectAs<TResponse>(expectedResponse?.Data, actualResponse?.Data);
        }

        protected void Assert400ResponseByRequest(
            HttpMessageModel request,
            HttpMessageModel expectedResponse,
            string additionalApiPath = null)
        {
            var actualResponse = SendRequest(request, Method, BasePath, additionalApiPath);
            AssertResponsesNoContentCheck(expectedResponse, actualResponse);
            AssertContentAs400(
                expectedResponse?.Data as BadModelResponse,
                actualResponse?.Data as BadModelResponse);
        }

        protected void AssertResponsesNoContentCheck(HttpMessageModel expected, HttpMessageModel actual)
        {
            AssertStatusCode(expected.StatusCode, actual.StatusCode);
            AssertHeaders(expected.Headers, actual.Headers);
            AssertContentAs400(expected.BadModel, actual.BadModel);
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

                Assert.Contains(actual, (a) => a.Key == headerExpected.Key);
                foreach (var valueActual in actual[headerExpected.Key])
                {
                    Assert.Contains(valueActual, expectedValues);
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

        protected void AssertContentAs400(BadModelResponse expected, BadModelResponse actual)
        {
            if (expected == null || actual == null)
            {
                return;
            }

            Assert.Equal(expected.Title, actual.Title);
            Assert.Equal(expected.Status, actual.Status);
            if (expected.Fields != null)
            {
                AssertList<string>(expected.Fields, actual.Fields);
            }
        }

        protected static void AssertList<T>(List<T> expected, List<T> actual)
        {
            Assert.Equal(expected?.Count, actual?.Count);
            AssertSoftList(expected, actual);
        }

        protected static void AssertSoftList<T>(List<T> expected, List<T> actual)
        {
            if (expected == null)
            {
                return;
            }

            foreach (var item in expected)
            {
                Assert.Contains(item, actual);
            }
        }

        protected static void AssertStringList(List<string> expected, List<string> actual)
        {
            expected.Sort();
            actual.Sort();
            var length = expected.Count;

            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < length; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }

        protected static void AssertSoftStringList(List<string> expected, List<string> actual)
        {
            expected.Sort();
            actual.Sort();
            var length = expected.Count;

            for (int i = 0; i < length; i++)
            {
                Assert.Contains(expected[i], actual);
            }
        }

        protected static void AssertGuid(string id)
        {
            Guid actualGuid;

            Assert.True(Guid.TryParse(id, out actualGuid));
            Assert.NotEqual(actualGuid, Guid.Empty);
        }

        public void Dispose()
        {
            App.Dispose();
        }
    }
}