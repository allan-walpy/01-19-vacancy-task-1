using System.ComponentModel.DataAnnotations;

namespace App.Server.Models.Database
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        public string ThirdName { get; set; }
    }
}