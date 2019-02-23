using System.ComponentModel;

namespace Walpy.VacancyApp.Server.All.Models
{
    /// <summary>
    /// Тип занятости
    /// </summary>
    [DisplayName("Тип занятости")]
    public enum EmploymentType
    {
        /// <summary>
        /// Полный день
        /// </summary>
        [DisplayName("Полный рабочий день")]
        FullTime = 0b01_00_00,

        /// <summary>
        /// Частичная занятость
        /// </summary>
        [DisplayName("Частичная занятость")]
        PartialTime = 0b10_00_00,

        /// <summary>
        /// Постоянный график
        /// </summary>
        [DisplayName("Постоянный график")]
        FixedScheldure = 0b00_01_00,

        /// <summary>
        /// Сменный график
        /// </summary>
        [DisplayName("Сменный график")]
        ShiftScheldure = 0b00_10_00,

        /// <summary>
        /// Гибкий график
        /// </summary>
        [DisplayName("Гибкий график")]
        FlexibleScheldure = 0b00_11_00,

        /// <summary>
        /// Удалённая работа
        /// </summary>
        [DisplayName("Удалённая работа")]
        RemoteMethod = 0b00_00_10,

        /// <summary>
        /// Вахтовый метод
        /// </summary>
        [DisplayName("Вахтовый метод")]
        ShiftMethod = 0b00_00_11
    }
}