using System;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Infrastructure
{
	public interface ISearchRepository<TEntity, TKey> where TEntity : class, IEntityKey<TKey>
	{
		IQueryable<TEntity> All();
		TEntity FindBy(Expression<Func<TEntity, bool>> expression);
		IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderBy = null);
		TEntity FindBy(TKey id);
	}
}