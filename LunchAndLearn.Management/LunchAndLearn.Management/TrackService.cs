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
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Management
{
  public class TrackService : ITrackService
  {
    private readonly ITrackRepository _trackRepository;

    public TrackService(ITrackRepository trackRepository)
    {
      _trackRepository = trackRepository;
    }

    public TrackDto Get(int id)
    {
      using (_trackRepository)
      {
        return _trackRepository.Get(id).ConvertToTrackDto(); 
      }
    }

    public List<TrackDto> GetAll()
    {
      using (_trackRepository)
      {
        var trackList =_trackRepository.GetAll().ToList();
        return trackList.Select(x => x.ConvertToTrackDto()).ToList();
      }
    }

    public TrackDto Create(TrackDto entity)
    {
      using (_trackRepository)
      {
        var entityToCreate = entity.ConvertToTrackDbModel();

        _trackRepository.Create(entityToCreate);
        _trackRepository.SaveChanges();

        return entityToCreate.ConvertToTrackDto();
      }
    }

    public TrackDto Update(TrackDto entity)
    {
      using (_trackRepository)
      {
        var entityToUpdate = entity.ConvertToTrackDbModel();

        _trackRepository.Update(entityToUpdate);
        _trackRepository.SaveChanges();

        return entityToUpdate.ConvertToTrackDto();
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
