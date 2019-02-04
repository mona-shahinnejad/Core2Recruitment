using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SIENN.DbAccess.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetAllQuery();
        IEnumerable<TEntity> GetRange(int start, int count);
        IEnumerable<TEntity> GetRange(int start, int count, Expression<Func<TEntity, bool>> predicate);

        int Count();

        int Count(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
