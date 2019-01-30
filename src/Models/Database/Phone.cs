using System.ComponentModel.DataAnnotations;

namespace App.Server.Models.Database
{
    public class Phone
    {
        [Key]
        public int Id { get; set;}

        [Required]
        public int PhoneRegion { get; set; }

        [Required]
        public int PhoneStateCode { get; set; }

        [Required]
        public int PhoneNumber { get; set; }
    }
}