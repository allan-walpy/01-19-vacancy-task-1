namespace App.Server.Models.Database
{
    /// <summary>
    /// Тип занятости
    /// </summary>
    public enum EmploymentType
    {
        /// <summary>
        /// Полный день
        /// </summary>
        FullTime,

        /// <summary>
        /// Частичная занятость
        /// </summary>
        PartialTime,

        /// <summary>
        /// Постоянный график
        /// </summary>
        FixedScheldure,

        /// <summary>
        /// Сменный график
        /// </summary>
        ShiftScheldure,

        /// <summary>
        /// Гибкий график
        /// </summary>
        FlexibleScheldure,

        /// <summary>
        /// Удалённая работа
        /// </summary>
        RemoteMethod,

        /// <summary>
        /// Вахтовый метод
        /// </summary>
        ShiftMethod
    }
}