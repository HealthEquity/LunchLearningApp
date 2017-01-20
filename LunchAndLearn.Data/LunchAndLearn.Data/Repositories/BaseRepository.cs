using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using LunchAndLearn.Data.Interfaces;

namespace LunchAndLearn.Data.Repositories
{
  public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    protected readonly LunchAndLearnContext DbContext;

    protected BaseRepository()
    {
       DbContext = new LunchAndLearnContext();
#if DEBUG
      DbContext.Database.Log = s => Debug.Write(s); 
#endif
    }

    public void Create(T entity)
    {
      DbContext.Set<T>().Add(entity);
    }

    public T Get(int id)
    {
      return DbContext.Set<T>().Find(id);
    }

    public List<T> GetAll()
    {
      return DbContext.Set<T>().ToList();
    }

    /// <summary>
    /// Method to retrieve collection based on specific criteria
    /// </summary>
    /// <param name="whereExpression">Ex: GetWithConditions(x => x.property == someProperty && x.anotherProperty == anotherProperty);</param>
    /// <returns>return a list of TEntity based on the where statement passed in</returns>
    public List<T> GetWithConditions(Expression<Func<T, bool>> whereExpression)
    {
      return DbContext.Set<T>().Where(whereExpression).ToList();
    }

    public void Update(T entity)
    {
      DbContext.Set<T>().Attach(entity);
      DbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      var entityToDelete = DbContext.Schedules.Find(id);
      DbContext.Entry(entityToDelete).State = EntityState.Deleted;
    }

    public abstract bool Exists(int id);


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
