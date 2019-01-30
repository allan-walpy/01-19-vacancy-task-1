using System.ComponentModel.DataAnnotations;

namespace App.Server.Models.Database
{
    public class ContactPersonModel
    {
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ThirdName { get; set; }
    }
}