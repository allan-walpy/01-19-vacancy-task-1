using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace App.Server.Models.Database
{
    public class DatabaseContext : DbContext
    {
        public static Person DefaultContactPerson
            => new Person
            {
                Name = null,
                Surname = null,
                ThirdName = null
            };

        public static EmploymentType[] DefaultEmploymentType
            => new EmploymentType[0];

        public static long DefaultLastUpdated
            => 0;

        public DbSet<VacancyModel> Vacancies { get; set; }
        public DbSet<OrganizationModel> Organizations { get; set; }

        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureVacancyTable(modelBuilder);
            ConfigureOrganizationTable(modelBuilder);
            ConfigureRelationships(modelBuilder);
        }

        private void ConfigureVacancyTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VacancyModel>()
                .Property(v => v.Id)
                .HasValueGenerator(typeof(GuidGenerator))
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<VacancyModel>()
                .Property(v => v.LastUpdated)
                .HasValueGenerator(typeof(CurrentTimestampGenerator))
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValue(Defaults.LastUpdated);

            modelBuilder.Entity<VacancyModel>()
                .Property(v => v.ContactPerson)
                .HasConversion(
                    (v) => JsonConvert.SerializeObject(v),
                    (j) => JsonConvert.DeserializeObject<Person>(j)
                );

            modelBuilder.Entity<VacancyModel>()
                .Property(v => v.EmploymentType)
                .HasConversion(
                    (v) => JsonConvert.SerializeObject(v),
                    (j) => JsonConvert.DeserializeObject<EmploymentType[]>(j)
                );
        }

        private void ConfigureOrganizationTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationModel>()
                .Property(o => o.Id)
                .HasValueGenerator(typeof(GuidGenerator))
                .ValueGeneratedOnAdd();
        }

        protected void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationModel>()
                .HasMany(o => o.Vacancy)
                .WithOne(v => v.Organization)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}