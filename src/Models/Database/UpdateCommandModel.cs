namespace App.Server.Models.Database
{
    public class UpdateCommandModel<TValue>
    {
        public bool IsModified { get; set; }

        public TValue Value { get; set; }
    }
}