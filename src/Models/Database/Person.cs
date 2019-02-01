using App.Server.Models.Attributes;

namespace App.Server.Models.Database
{
    public class Person
    {

        [ValidPersonName]
        public string Name { get; set; }

        [ValidPersonName]
        public string Surname { get; set; }

        [ValidPersonName]
        public string ThirdName { get; set; }
    }
}