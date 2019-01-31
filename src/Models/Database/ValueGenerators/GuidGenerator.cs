using System;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Server.Models.Database.ValueGenerators
{
    public class GuidGenerator : ValueGenerator<string>
    {
        private string Generate()
            => Guid.NewGuid().ToString();

        public override bool GeneratesTemporaryValues
            => false;

        public override string Next(EntityEntry entry)
            => Generate();
    }
}