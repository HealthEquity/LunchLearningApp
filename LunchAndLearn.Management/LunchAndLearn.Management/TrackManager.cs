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
    private readonly ITrackRepository _trackRepository;

    public TrackManager(ITrackRepository trackRepository)
    {
      _trackRepository = trackRepository;
    }

    public Track Get(int id)
    {
      using (_trackRepository)
      {
        return _trackRepository.Get(id); 
      }
    }

    public List<Track> GetAll()
    {
      using (_trackRepository)
      {
        return _trackRepository.GetAll().ToList(); 
      }
    }

    public int Create(Track entity)
    {
      using (_trackRepository)
      {
        _trackRepository.Create(entity);
        _trackRepository.SaveChanges();
        return entity.TrackId; 
      }
    }

    public void Update(Track entity)
    {
      using (_trackRepository)
      {
        _trackRepository.Update(entity);
        _trackRepository.SaveChanges(); 
      }
    }

    public void Delete(int id)
    {
      using (_trackRepository)
      {
        _trackRepository.Delete(id);
        _trackRepository.SaveChanges(); 
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
          _trackRepository.Dispose();
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
