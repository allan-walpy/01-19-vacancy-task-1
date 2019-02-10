namespace Walpy.VacancyApp.Server.Models.Responses
{
    public abstract class CustomErrorResponse
    {
        public abstract int StatusCode { get; }
    }
}