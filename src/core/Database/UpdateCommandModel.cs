namespace Walpy.VacancyApp.Server.Core.Database
{
    /// <summary>
    /// Обновление параметра
    /// </summary>
    /// <typeparam name="TValue">Тип значения параметра</typeparam>
    public class UpdateCommandModel<TValue>
    {
        /// <summary>
        /// Указывает изменять ли параметр
        /// </summary>
        /// <example>true</example>
        public bool IsModified { get; set; }

        /// <summary>
        /// Новое значение параметра
        /// </summary>
        /// <example>0</example>
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