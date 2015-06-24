using System.Collections.Generic;

namespace DAL.Infrastructure
{
    public interface IPersistRepository<TEntity>
    {
        bool Add(TEntity entity);
        bool Add(IEnumerable<TEntity> items);
        bool Update(TEntity entity);
        bool Delete(object id);
        bool Delete(TEntity entity);
        bool Delete(IEnumerable<TEntity> entities);
    }
}