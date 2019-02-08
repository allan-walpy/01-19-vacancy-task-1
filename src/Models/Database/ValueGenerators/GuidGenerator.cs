using System;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Walpy.VacancyApp.Server.Models.Database.ValueGenerators
{
    public class GuidGenerator : ValueGenerator<string>
    {
        private static string Generate()
            => Guid.NewGuid().ToString();

        public override bool GeneratesTemporaryValues
            => false;

        public override string Next(EntityEntry entry)
            => Generate();
    }
}