using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using LunchAndLearn.Data.Interfaces;

namespace LunchAndLearn.Data.Repositories
{
  public class LunchAndLearnRepository<T> : ILunchAndLearnRepository<T> where T : class
  {
    private readonly LunchAndLearnContext _databaseContext = new LunchAndLearnContext();

    public LunchAndLearnRepository()
    {
      Initialize();
    }

    private void Initialize()
    {
      _databaseContext.Set<T>();
    }

    public void Create(T entity)
    {
      _databaseContext.Set<T>().Add(entity);
    }

    public T Get(int id)
    {
      return _databaseContext.Set<T>().Find(id);
    }

    public void Update(T entity)
    {
      _databaseContext.Set<T>().Attach(entity);
      _databaseContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      var entityToDelete = _databaseContext.Set<T>().Find(id);
      _databaseContext.Entry(entityToDelete).State = EntityState.Deleted;
    }

    public IQueryable<T> GetAll()
    {
      return _databaseContext.Set<T>();
    }

    public void SaveChanges()
    {
      _databaseContext.Set<T>();
      _databaseContext.SaveChanges();
    }

    #region Disposal
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          _databaseContext.Dispose();
#if DEBUG
          Debug.WriteLine($"Repository of type {typeof(T)} DISPOSED!");
#endif
        }
      }
      this.disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    } 
    #endregion
  }
}
