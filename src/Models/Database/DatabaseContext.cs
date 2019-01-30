using Microsoft.EntityFrameworkCore;

namespace App.Server.Models.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vacancy>()
                .Property(v => v.LastUpdated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}