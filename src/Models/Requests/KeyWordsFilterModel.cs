using System.ComponentModel.DataAnnotations;

using App.Server.Models.Attributes;
using App.Server.Models.Services;

namespace App.Server.Models.Requests
{
    [AnyNotNull(nameof(SearchString))]
    public class KeyWordsFilterModel
    {
        [Required]
        public string SearchString { get; set; }

        [Required]
        [ValidEnum(typeof(KeyWordsFilter.SearchStringMatch))]
        public string Match { get; set; }

        [Required]
        [ValidEnum(typeof(KeyWordsFilter.SearchStringScope))]
        public string Scope { get; set; }
    }
}