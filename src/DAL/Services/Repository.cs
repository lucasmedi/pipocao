using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Services
{
    public class Repository<T, TKey> : IPersistRepository<T>, ISearchRepository<T, TKey> where T : class, IEntityKey<TKey>
    {
        internal readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public IQueryable<T> All()
        {
            return _session.Query<T>();
        }

        public T FindBy(Expression<Func<T, bool>> expression)
        {
            return FilterBy(expression).SingleOrDefault();
        }

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderBy = null)
        {
            var query = All().Where(expression);

            if (orderBy != null)
            {
                query.OrderBy(orderBy);
            }

            return query.AsQueryable();
        }

        public T FindBy(TKey id)
        {
            return _session.Get<T>(id);
        }

        public T[] QueryOver(Expression<Func<T>> query)
        {
            return _session.QueryOver<T>(query).List().ToArray();
        }

        public bool Add(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(entity);

                transaction.Commit();
            }

            return true;
        }

        public bool Add(IEnumerable<T> entities)
        {
            using (var transaction = _session.BeginTransaction())
            {
                foreach (T entity in entities)
                    _session.Save(entity);

                transaction.Commit();
            }

            return true;
        }

        public bool Update(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Merge(entity);

                transaction.Commit();
            }

            return true;
        }

        public bool Delete(object id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(_session.Load(typeof(T), id));

                transaction.Commit();
            }

            return true;
        }

        public bool Delete(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(entity);

                transaction.Commit();
            }

            return true;
        }

        public bool Delete(IEnumerable<T> entities)
        {
            using (var transaction = _session.BeginTransaction())
            {
                foreach (T entity in entities)
                    _session.Delete(entity);

                transaction.Commit();
            }

            return true;
        }
    }
}