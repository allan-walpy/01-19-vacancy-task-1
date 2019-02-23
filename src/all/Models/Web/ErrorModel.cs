using System;

namespace Walpy.VacancyApp.Server.All.Models.Web
{
    public class ErrorModel
    {
        public int StatusCode { get; set; }
        public string Path { get; set; }
        public Exception Error { get; set; }
        public string Message { get; set; }
    }
}