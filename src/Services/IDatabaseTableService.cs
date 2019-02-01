namespace App.Server.Services
{
    public interface IDatabaseTableService<TModel, TId>
        where TModel : class
    {
        TModel Get(TId id);

        bool Add(TModel vacancy);

        TModel Update(TId id, TModel updatedItem);

        bool Delete(TId id);
    }
}