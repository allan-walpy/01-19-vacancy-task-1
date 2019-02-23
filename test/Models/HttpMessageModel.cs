using System.Collections.Generic;

using Walpy.VacancyApp.Server.All.Models.Responses;

namespace Walpy.VacancyApp.Test.Models
{
    public class HttpMessageModel
    {
        public ApiCallModel ApiCall { get; set; }

        public int? StatusCode { get; set; }

        public Dictionary<string, string[]> Headers { get; set; }

        public object Data { get; set; }

        public BadModelResponse BadModel { get; set; }
    }
}