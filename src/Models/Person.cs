using System.ComponentModel.DataAnnotations;

using App.Server.Models.Attributes;

namespace App.Server.Models
{
    public class Person
    {
        [Required]
        [ValidPersonName]
        public string Name { get; set; }

        [ValidPersonName]
        public string Surname { get; set; }

        [ValidPersonName]
        public string ThirdName { get; set; }
    }
}