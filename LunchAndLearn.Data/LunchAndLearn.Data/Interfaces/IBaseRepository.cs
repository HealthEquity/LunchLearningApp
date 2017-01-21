using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LunchAndLearn.Data.Interfaces
{
  public interface IBaseRepository<TEntity> : IDisposable
  {
    void Create(TEntity entity);
    TEntity Get(int id);
    List<TEntity> GetAll();
    List<TEntity> GetWithConditions(Expression<Func<TEntity, bool>> whereExpression);
    void Update(TEntity entity);
    void Delete(int id);
    bool Exists(Expression<Func<TEntity, bool>> condition);
    void SaveChanges();
  }
}
