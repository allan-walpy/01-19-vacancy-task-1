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
        FullTime = 0b01_00_00,

        /// <summary>
        /// Частичная занятость
        /// </summary>
        PartialTime = 0b10_00_00,

        /// <summary>
        /// Постоянный график
        /// </summary>
        FixedScheldure = 0b00_01_00,

        /// <summary>
        /// Сменный график
        /// </summary>
        ShiftScheldure = 0b00_10_00,

        /// <summary>
        /// Гибкий график
        /// </summary>
        FlexibleScheldure = 0b00_11_00,

        /// <summary>
        /// Удалённая работа
        /// </summary>
        RemoteMethod = 0b00_00_10,

        /// <summary>
        /// Вахтовый метод
        /// </summary>
        ShiftMethod = 0b00_00_11
    }
}