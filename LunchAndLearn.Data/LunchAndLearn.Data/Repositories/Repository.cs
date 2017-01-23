using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using LunchAndLearn.Data.Interfaces;

namespace LunchAndLearn.Data.Repositories
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    internal LunchAndLearnContext DbContext;
    internal DbSet<TEntity> DbSet;

    public Repository(LunchAndLearnContext context)
    {
      DbContext = context;
      DbSet = context.Set<TEntity>();
    }

    public virtual IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "")
    {
      IQueryable<TEntity> query = DbSet;

      if (filter != null)
      {
        query = query.Where(filter);
      }

      foreach (var includeProperty in includeProperties.Split
          (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
      {
        query = query.Include(includeProperty);
      }

      if (orderBy != null)
      {
        return orderBy(query).ToList();
      }

      return query.ToList();
    }

    public virtual TEntity GetById(object id)
    {
      return DbSet.Find(id);
    }

    public virtual void Insert(TEntity entity)
    {
      DbSet.Add(entity);
    }

    public virtual void Delete(object id)
    {
      TEntity entityToDelete = DbSet.Find(id);
      Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
      if (DbContext.Entry(entityToDelete).State == EntityState.Detached)
      {
        DbSet.Attach(entityToDelete);
      }
      DbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
      DbSet.Attach(entityToUpdate);
      DbContext.Entry(entityToUpdate).State = EntityState.Modified;
    }

    public virtual bool Exists(Expression<Func<TEntity, bool>> condition)
    {
      return DbSet.Any(condition);
    }
  }
}
