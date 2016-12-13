using LunchAndLearn.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearn.Management
{
  public class BaseManager : IDisposable
  {
    protected LunchAndLearnContext Context { get; private set; }

    private bool _privateContext = false;

    public BaseManager()
        : this(new LunchAndLearnContext())
    {
      _privateContext = true;
    }

    public BaseManager(LunchAndLearnContext context)
    {
      Context = context;
    }

    /// <summary>
    /// Adds a new entity to the set.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    protected void AddEntity<T>(T entity) where T : class
    {
      Context.Set<T>().Add(entity);
    }

    /// <summary>
    /// Updates an existing entity. This sets the entire entity and all properties to Modified.
    /// Use the SetModified method to edit a single property without first loading from the database.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    protected void UpdateEntity<T>(T entity) where T : class
    {
      Context.Set<T>().Attach(entity);
      Context.Entry(entity).State = EntityState.Modified;
    }

    /// <summary>
    /// Removes an entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    protected void DeleteEntity<T>(T entity) where T : class
    {
      Context.Set<T>().Attach(entity);
      Context.Entry(entity).State = EntityState.Deleted;
    }

    /// <summary>
    /// Marks a single property (or properties) as modified. This allows a stub entity to be
    /// created with only the modified values to be saved to the database.  For example:
    /// <para>
    ///     var account = new Account { Id = 5, Name = "Bob" };
    ///     SetModified(account, a => a.Name);
    /// </para>
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <typeparam name="TProp">Property type</typeparam>
    /// <param name="entity">Entity to update</param>
    /// <param name="properties">Property selector functions</param>
    protected void SetModified<T, TProp>(T entity, params Expression<Func<T, TProp>>[] properties) where T : class
    {
      Context.Set<T>().Attach(entity);

      foreach (var prop in properties)
        Context.Entry(entity).Property(prop).IsModified = true;
    }


    /// <summary>
    /// Reload's an entity from the database, overwriting current values.
    /// </summary>
    /// <param name="entity">Entity to reload</param>
    public void ReloadEntity<T>(T entity) where T : class
    {
      Context.Entry(entity).Reload();
    }


    /// <summary>
    /// Runs default attribute validation against the provided model.  Validation failure results in throwing a
    /// ValidationException which contains an AggregateException as its InnerException. The AggregateException contains
    /// all validation failures.
    /// 
    /// Validation behavior may be customized by overriding this method.
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    /// <param name="entity">Model entity</param>
    public virtual void ValidateModel<T>(T entity) where T : class
    {
      var results = new List<ValidationResult>();
      bool isValid = ValidateAnnotations(entity, results);

      if (!isValid)
      {
        var exceptions = results.Select(r => new ValidationException(r, null, null));
        throw new ValidationException(typeof(T).Name, new AggregateException(exceptions));
      }
    }


    /// <summary>
    /// Runs default attribute validation against the provided model.  On validation failure, stores validation results in 
    /// the provided collection and returns False.
    /// 
    /// Validation behavior may be customized by overriding this method.
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    /// <param name="entity">Model entity</param>
    /// <param name="results">Validation results</param>
    /// <returns>True on validation success, otherwise false</returns>
    public virtual bool TryValidateModel<T>(T entity, ICollection<ValidationResult> results) where T : class
    {
      return ValidateAnnotations(entity, results);
    }


    /// <summary>
    /// Run attribute validation on the given entity, storing the results in the provided collection
    /// </summary>
    /// <returns>True on validation success, otherwise false</returns>
    private bool ValidateAnnotations<T>(T entity, ICollection<ValidationResult> results) where T : class
    {
      return Validator.TryValidateObject(entity, new ValidationContext(entity), results, true);
    }


    #region IDisposable

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    public virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (_privateContext && Context != null)
          Context.Dispose();
      }
    }

    #endregion
  }
}
