using System.Collections.Generic;

namespace App.Server.Test.Models
{
    public class HttpMessageModel
    {
        public ApiCallModel ApiCall { get; set; }

        public int? StatusCode { get; set; }

        public Dictionary<string, string[]> Headers { get; set; }

        public object Data { get; set; }
    }
}