using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

using App.Server.Models.Database.ValueGenerators;

namespace App.Server.Models.Database
{
    public class DatabaseContext : DbContext
    {
        private static long DefaultTimestamp => 0;
        private static string DefaultGuid => System.Guid.Empty.ToString();

        public DbSet<VacancyModel> Vacancies { get; set; }
        public DbSet<OrganizationModel> Organizations { get; set; }

        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //? thnx to
        //?     https://github.com/aspnet/EntityFrameworkCore/issues/3955#issuecomment-161757265 ;
        //?     fixes Vacancy.LastUpdate with `ValueGeneratedOnAddOrUpdate` not working;
        //! this method also not working due to requirment of `ValueGeneratedOnAddOrUpdate`
        //!     in `HasDefaultValue`/`HasDefaultValueSql` any changes rewritten on default value anyway;
        //TODO:FIXME:;
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var nowTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            UpdateEntriesWith<VacancyModel, long>(
                states: new List<EntityState> { EntityState.Added, EntityState.Modified },
                propertyName: nameof(VacancyModel.LastUpdated),
                value: nowTimestamp);

            return base.SaveChanges();
        }

        private void UpdateEntriesWith<TModel, TValue>(
            List<EntityState> states,
            string propertyName,
            TValue value)
            where TModel : class
            => states.ForEach((state) => UpdateEntriesWith<TModel, TValue>(state, propertyName, value));

        private void UpdateEntriesWith<TModel, TValue>(
            EntityState state,
            string propertyName,
            TValue value)
            where TModel : class
        {
            foreach (var item in GetEntriesWith<TModel>(state))
            {
                SetEntrieValue(item, propertyName, value);
            }
        }

        private IEnumerable<EntityEntry<T>> GetEntriesWith<T>(EntityState state)
            where T : class
            => ChangeTracker.Entries<T>().Where(e => e.State == state);

        private void SetEntrieValue<TModel, TValue>(
            EntityEntry<TModel> item,
            string propertyName,
            TValue value)
            where TModel : class
        {
            item.Property(propertyName).CurrentValue = value;
            item.Property(propertyName).IsTemporary = true;
            item.Property(propertyName).IsModified = true;
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
                .ValueGeneratedOnAdd()
                .HasDefaultValue(DefaultGuid);

            modelBuilder.Entity<VacancyModel>()
                .Property(v => v.LastUpdated)
                .HasValueGenerator(typeof(CurrentTimestampGenerator))
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValue(DefaultTimestamp);

            modelBuilder.Entity<VacancyModel>()
                .Property(v => v.CreatedAt)
                .HasValueGenerator(typeof(CurrentTimestampGenerator))
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValue(DefaultTimestamp);

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
                .ValueGeneratedOnAdd()
                .HasDefaultValue(DefaultGuid);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationModel>()
                .HasMany(o => o.Vacancy)
                .WithOne(v => v.Organization)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}