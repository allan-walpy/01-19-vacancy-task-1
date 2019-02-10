namespace Walpy.VacancyApp.Server.Models.Responses
{
    public class ErrorResponse : CustomErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public override int StatusCode => 500;
    }
}