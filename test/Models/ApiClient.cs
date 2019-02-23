using System.Net.Http;

namespace Walpy.VacancyApp.Test.Models
{
    public class ApiClient
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
    }
}