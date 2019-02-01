namespace App.Server.Models.Database
{
    public class UpdateCommandModel<TValue>
    {
        public bool IsModified { get; set; }

        public TValue Value { get; set; }

        public static explicit operator UpdateCommandModel<object>(UpdateCommandModel<TValue> value)
        {
            return new UpdateCommandModel<object>
            {
                IsModified = value.IsModified,
                Value = value.Value
            };
        }
    }
}