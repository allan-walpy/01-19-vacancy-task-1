namespace Walpy.VacancyApp.Server.Models.Responses
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public int StatucCode => 500;
    }
}