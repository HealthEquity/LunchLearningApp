using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Management
{
  public class TrackManager : IManagerClass<Track>
  {
    private readonly ILunchAndLearnRepository<Track> _lunchAndLearnRepository;

    public TrackManager(ILunchAndLearnRepository<Track> lunchAndLearnRepository)
    {
      _lunchAndLearnRepository = lunchAndLearnRepository;
    }

    public Track Get(int id)
    {
      return _lunchAndLearnRepository.Get(id);
    }

    public List<Track> GetAll()
    {
      return _lunchAndLearnRepository.GetAll().ToList();
    }

    public int Create(Track entity)
    {
      _lunchAndLearnRepository.Create(entity);
      _lunchAndLearnRepository.SaveChanges();
      return entity.TrackId;
    }

    public void Update(Track entity)
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
