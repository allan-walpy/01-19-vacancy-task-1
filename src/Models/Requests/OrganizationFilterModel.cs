using App.Server.Models.Attributes;

namespace App.Server.Models.Requests
{
    /// <summary>
    /// Настройки фильтра поиска по нанимателю
    /// </summary>
    /// <remarks>
    /// Указывается одно из полей, приоритет отдается полю <see cref="Id" />
    /// </remarks>
    [AnyNotNull(nameof(Id), nameof(Name))]
    public class OrganizationFilterModel
    {
        /// <summary>
        /// Guid нанимателя
        /// </summary>
        /// <example>0e51bbe4-4b9f-4942-88c1-d7f657272099</example>
        [ValidGuidStringOrNull]
        public string Id { get; set; }

        /// <summary>
        /// Название организации-нанимателя
        /// </summary>
        /// <example>ООО "Скучная компания"</example>
        [ValidOrganizationName]
        public string Name { get; set; }
    }
}