namespace App.Server.Models.Database
{
    public static class Defaults
    {
        public static Person ContactPerson
            => new Person
            {
                Name = null,
                Surname = null,
                ThirdName = null
            };

        public static EmploymentType[] EmploymentType
            => new EmploymentType[0];

        public static long LastUpdated
            => 0;
    }
}