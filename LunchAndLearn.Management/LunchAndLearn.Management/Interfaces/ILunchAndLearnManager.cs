using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace LunchAndLearn.Management
{
  public interface ILunchAndLearnManager
  {
    ClassManager ClassManager { get; }
    InstructorManager InstructorManager { get; }
    RatingManager RatingManager { get; }
    TrackManager TrackManager { get; }
    ScheduleManager ScheduleManager { get; }
    RoomManager RoomManager { get; }
    int SaveChanges();
    LunchAndLearnManager Resolve<T>(ref IQueryable<T> query, IEnumerable<string> paths) where T : class;
    LunchAndLearnManager Resolve<T, TProp>(ref IQueryable<T> query, Expression<Func<T, TProp>> path) where T : class;

    /// <summary>
    /// Reload's an entity from the database, overwriting current values.
    /// </summary>
    /// <param name="entity">Entity to reload</param>
    void ReloadEntity<T>(T entity) where T : class;

    /// <summary>
    /// Runs default attribute validation against the provided model.  Validation failure results in throwing a
    /// ValidationException which contains an AggregateException as its InnerException. The AggregateException contains
    /// all validation failures.
    /// 
    /// Validation behavior may be customized by overriding this method.
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    /// <param name="entity">Model entity</param>
    void ValidateModel<T>(T entity) where T : class;

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
    bool TryValidateModel<T>(T entity, ICollection<ValidationResult> results) where T : class;

    void Dispose();
    void Dispose(bool disposing);
  }
}