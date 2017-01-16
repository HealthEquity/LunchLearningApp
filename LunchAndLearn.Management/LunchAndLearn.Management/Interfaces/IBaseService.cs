using System;
using System.Collections.Generic;
using System.Linq;
using LunchAndLearn.Data.Interfaces;

namespace LunchAndLearn.Management.Interfaces
{
  public interface IBaseService<TEntity> : IDisposable
  {
    TEntity Get(int id);
    List<TEntity> GetAll();
    int Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(int id);
  }
}