using System.Net.Http;

namespace App.Server.Test.Models
{
    public class ApiCallModel
    {
        public HttpMethod Method { get; set; }

        public ApiPathModel Path { get; set; }

        public HttpRequestMessage ToRequest()
            => new HttpRequestMessage(Method, Path.ToString());
    }
}