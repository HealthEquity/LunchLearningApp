using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LunchAndLearn.Data.Interfaces
{
  public interface IRepository<TEntity> where TEntity : class
  {
    IEnumerable<TEntity> Get(
      Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = "");

    TEntity GetById(object id);
    void Insert(TEntity entity);
    void Delete(object id);
    void Delete(TEntity entityToDelete);
    void Update(TEntity entityToUpdate);
    bool Exists(Expression<Func<TEntity, bool>> condition);
  }
}