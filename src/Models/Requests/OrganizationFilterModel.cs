using App.Server.Models.Attributes;

namespace App.Server.Models.Requests
{
    [AnyNotNull(nameof(Id), nameof(Name))]
    public class OrganizationFilterModel
    {
        [ValidGuidStringOrNull]
        public string Id { get; set; }

        [ValidOrganizationName]
        public string Name { get; set; }
    }
}