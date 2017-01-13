using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LunchAndLearn.Data.Interfaces
{
  public interface IBaseRepository<TEntity> : IDisposable
  {
    void Create(TEntity entity);
    TEntity Get(int id);
    IQueryable<TEntity> GetAll();
    void Update(TEntity entity);
    void Delete(int id);
    void SaveChanges();
  }
}
