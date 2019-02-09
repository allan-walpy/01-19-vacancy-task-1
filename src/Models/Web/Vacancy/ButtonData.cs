namespace Walpy.VacancyApp.Server.Models.Web
{
    public enum ButtonDataAction
    {
        View,
        Edit,
        Delete
    }

    public class ButtonData
    {
        public ButtonDataAction ActionType { get; set; }
        public string VacancyId { get; set; }
    }
}