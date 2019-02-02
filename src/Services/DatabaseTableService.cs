using System;
using Microsoft.EntityFrameworkCore;

using App.Server.Models.Database;

namespace App.Server.Services
{
    public abstract class DatabaseTableService<TModel, TId>
        : IDatabaseTableService<TModel, TId>
        where TModel : class
    {
        private Action<TModel> OnAddAction { get; }
        private Action<TModel> OnUpdateAction { get; }
        protected IDatabaseService DatabaseService { get; }

        public DatabaseTableService(
            Action<TModel> onAddAction,
            Action<TModel> onUpdateAction,
            IDatabaseService databaseService)
        {
            OnAddAction = onAddAction;
            OnUpdateAction = onUpdateAction;
            DatabaseService = databaseService;
        }

        protected abstract DbSet<TModel> GetTable(DatabaseContext databaseContext);

        public virtual TModel Get(TId id)
        {
            using (var databaseContext = DatabaseService.GetContext())
            {
                return GetTable(databaseContext).Find(id);
            }
        }

        public virtual bool Add(TModel item)
        {
            OnAddAction(item);
            using (var databaseContext = DatabaseService.GetContext())
            {
                GetTable(databaseContext).Add(item);
                return databaseContext.SaveChanges() > 0;
            }
        }

        public virtual TModel Update(TId id, TModel updatedItem)
        {
            var item = Get(id);
            if (item == null)
            {
                return null;
            }

            OnUpdateAction(updatedItem);
            using (var databaseContext = DatabaseService.GetContext())
            {
                GetTable(databaseContext).Update(updatedItem);
                databaseContext.SaveChanges();
                return updatedItem;
            }
        }

        public virtual bool Delete(TId id)
        {
            var item = Get(id);
            if (item == null)
            {
                return false;
            }

            using (var databaseContext = DatabaseService.GetContext())
            {
                GetTable(databaseContext).Remove(item);
                return databaseContext.SaveChanges() > 0;
            }
        }
    }
}