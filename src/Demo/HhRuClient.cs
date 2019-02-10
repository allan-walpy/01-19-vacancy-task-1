using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

using Walpy.VacancyApp.Server.Models.Responses;

namespace Walpy.VacancyApp.Server.Demo
{
    public class HhRuClient
    {
        private static readonly string _userAgentTemplate = $"{nameof(Walpy.VacancyApp.Server)}/{{0}} ({{1}}@gmail.com)";
        private const string _gmail = "allanwalpy";
        public const string BaseUrl = "https://api.hh.ru/";

        private IConfiguration Configuration { get; }
        public string UserAgentValue
            => String.Format(_userAgentTemplate, Configuration["version"], _gmail);

        public HhRuClient(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private void CompleteRequest(HttpRequestMessage request, string urlAddition)
        {
            request.RequestUri = new Uri(BaseUrl + urlAddition);
        }

        public string SendRequest(HttpRequestMessage request, string urlAddition)
        {
            using (var client = new HttpClient())
            {

            }
        }

        /*    public class ApiClient
    {
        protected static ApiCallModel AddApiCall { get; set; }

        public HttpResponseMessage Send(HttpMessageModel requestInfo)
            => Send(requestInfo.ToRequest());

        protected static HttpResponseMessage Send(HttpRequestMessage request)
        {
            using (var client = new HttpClient())
            {
                return client.SendAsync(request).Result;
            }
        }
    } */
    }
}