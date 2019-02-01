using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using App.Server.Models.Database;

namespace App.Server.Services
{
    public class DatabaseOrganizationService
        : DatabaseTableService<OrganizationModel, string>, IDatabaseOrganizationService
    {
        public DatabaseOrganizationService(IDatabaseService databaseService)
            : base(
                onAddAction: null,
                onUpdateAction: null,
                databaseService: databaseService)
        { }

        protected override DbSet<OrganizationModel> GetTable(DatabaseContext databaseContext)
            => databaseContext.Organizations;

        public override OrganizationModel Update(string id, OrganizationModel updatedItem)
            => throw new InvalidOperationException("Organization records can't be updated");

        private bool NamePredicateMethod(OrganizationModel item, string requestName)
            => String.Compare(item.Name, requestName, StringComparison.InvariantCulture) == 0;

        public OrganizationModel GetByName(string name)
        {
            using (var databaseContext = DatabaseService.GetContext())
            {
                return GetTable(databaseContext)
                    .Where((organization) => NamePredicateMethod(organization, name))
                    .SingleOrDefault();
            }
        }
    }
}