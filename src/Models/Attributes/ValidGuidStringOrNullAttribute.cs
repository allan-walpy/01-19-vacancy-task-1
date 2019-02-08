namespace Walpy.VacancyApp.Server.Models.Attributes
{
    public class ValidGuidStringOrNullAttribute : ValidGuidStringAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return base.IsValid(value);
        }
    }
}