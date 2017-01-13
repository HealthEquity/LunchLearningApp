using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Management
{
  public class RatingManager : IManagerClass<Rating>
  {
    private readonly IRatingRepository _ratingRepository;

    public RatingManager(IRatingRepository ratingRepository)
    {
      _ratingRepository = ratingRepository;
    }

    public Rating Get(int id)
    {
      using (_ratingRepository)
      {
        return _ratingRepository.Get(id); 
      }
    }

    public List<Rating> GetAll()
    {
      using (_ratingRepository)
      {
        return _ratingRepository.GetAll().ToList(); 
      }
    }

    public int Create(Rating entity)
    {
      using (_ratingRepository)
      {
        _ratingRepository.Create(entity);
        _ratingRepository.SaveChanges();
        return entity.RatingId; 
      }
    }

    public void Update(Rating entity)
    {
      using (_ratingRepository)
      {
        _ratingRepository.Update(entity);
        _ratingRepository.SaveChanges(); 
      }
    }

    public void Delete(int id)
    {
      using (_ratingRepository)
      {
        _ratingRepository.Delete(id);
        _ratingRepository.SaveChanges(); 
      }
    }

    #region Disposal
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposed)
      {
        if (disposing)
        {
          _ratingRepository.Dispose();
        }
      }
      this._disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    #endregion
  }
}