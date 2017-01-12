using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management.Interfaces;

namespace LunchAndLearn.Management
{
  public class RatingManager : IManagerClass<Rating>
  {
    private readonly ILunchAndLearnRepository<Rating> _lunchAndLearnRepository;

    public RatingManager(ILunchAndLearnRepository<Rating> lunchAndLearnRepository)
    {
      _lunchAndLearnRepository = lunchAndLearnRepository;
    }

    public Rating Get(int id)
    {
      return _lunchAndLearnRepository.Get(id);
    }

    public List<Rating> GetAll()
    {
      return _lunchAndLearnRepository.GetAll().ToList();
    }

    public int Create(Rating entity)
    {
      _lunchAndLearnRepository.Create(entity);
      _lunchAndLearnRepository.SaveChanges();
      return entity.RatingId;
    }

    public void Update(Rating entity)
    {
      _lunchAndLearnRepository.Update(entity);
      _lunchAndLearnRepository.SaveChanges();
    }

    public void Delete(int id)
    {
      _lunchAndLearnRepository.Delete(id);
      _lunchAndLearnRepository.SaveChanges();
    }

    #region Disposal
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposed)
      {
        if (disposing)
        {
          _lunchAndLearnRepository.Dispose();
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