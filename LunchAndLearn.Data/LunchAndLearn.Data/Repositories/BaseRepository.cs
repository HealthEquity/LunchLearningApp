using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using LunchAndLearn.Data.Interfaces;

namespace LunchAndLearn.Data.Repositories
{
  public class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    protected readonly LunchAndLearnContext DbContext;

    public BaseRepository()
    {
       DbContext = new LunchAndLearnContext();
#if DEBUG
      DbContext.Database.Log = s => Debug.Write(s); 
#endif
      Initialize();
    }

    private void Initialize()
    {
      DbContext.Set<T>();
    }

    public void Create(T entity)
    {
      DbContext.Set<T>().Add(entity);
    }

    public T Get(int id)
    {
      return DbContext.Set<T>().Find(id);
    }

    public void Update(T entity)
    {
      DbContext.Set<T>().Attach(entity);
      DbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      var entityToDelete = DbContext.Set<T>().Find(id);
      DbContext.Entry(entityToDelete).State = EntityState.Deleted;
    }

    public IQueryable<T> GetAll()
    {
      return DbContext.Set<T>();
    }

    public void SaveChanges()
    {
      DbContext.Set<T>();
      DbContext.SaveChanges();
    }

    #region Disposal
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          DbContext.Dispose();
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
