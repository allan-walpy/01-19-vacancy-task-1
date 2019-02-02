using System.ComponentModel.DataAnnotations;

using App.Server.Models.Attributes;

namespace App.Server.Models.Requests
{
    [AnyNotNull(nameof(SearchString))]
    public class KeyWordsFilterModel
    {
        public enum SearchStringMatch
        {
            AnyWord,
            AllWords,
            ExactMatch
        }

        public enum SearchStringScope
        {
            Title,
            Description,
            Both
        }

        [Required]
        public string SearchString { get; set; }

        [Required]
        [ValidEnum(typeof(SearchStringMatch))]
        public SearchStringMatch Match { get; set; }

        [Required]
        [ValidEnum(typeof(SearchStringScope))]
        public SearchStringScope Scope { get; set; }
    }
}