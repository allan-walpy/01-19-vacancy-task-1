using System;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Server.Models.Database
{
    public class CurrentTimestampGenerator : ValueGenerator<long>
    {
        private long Generate()
            => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        public override bool GeneratesTemporaryValues
            => true;

        public override long Next(EntityEntry entry)
            => Generate();
    }
}