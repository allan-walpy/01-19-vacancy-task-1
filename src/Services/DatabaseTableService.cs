using System;
using Microsoft.EntityFrameworkCore;

using Walpy.VacancyApp.Server.Models.Database;

namespace Walpy.VacancyApp.Server.Services
{
    public abstract class DatabaseTableService<TModel, TId>
        : IDatabaseTableService<TModel, TId>
        where TModel : class
    {
        private static Action<TModel> NoneActionOnModelChange
            => (item) => {};

        private Action<TModel> OnAddAction { get; }
        private Action<TModel> OnUpdateAction { get; }
        protected IDatabaseService DatabaseService { get; }

        protected DatabaseTableService(
            Action<TModel> onAddAction,
            Action<TModel> onUpdateAction,
            IDatabaseService databaseService)
        {
            OnAddAction = onAddAction ?? NoneActionOnModelChange;
            OnUpdateAction = onUpdateAction ?? NoneActionOnModelChange;
            DatabaseService = databaseService;
        }

        protected abstract DbSet<TModel> GetTable(DatabaseContext databaseContext);

        protected abstract TId GetId(TModel item);

        public virtual TModel Get(TId id)
        {
            using (var databaseContext = DatabaseService.GetContext())
            {
                return GetTable(databaseContext).Find(id);
            }
        }

        public virtual TId Add(TModel item)
        {
            OnAddAction(item);
            using (var databaseContext = DatabaseService.GetContext())
            {
                GetTable(databaseContext).Add(item);
                var success = databaseContext.SaveChanges() > 0;
                return success ? GetId(item) : default(TId);
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