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
    private readonly IUnitOfWork _unitOfWork;

    public TrackService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public TrackDto Get(int trackId)
    {
      return _unitOfWork.TrackRepository.GetById(trackId).ConvertToTrackDto();
    }

    public List<TrackDto> GetAll()
    {
      return _unitOfWork.TrackRepository.Get().Select(x => x.ConvertToTrackDto()).ToList();
    }

    public TrackDto Create(TrackDto trackDto)
    {
      var trackDbModelToCreate = trackDto.ConvertToTrackDbModel();

      _unitOfWork.TrackRepository.Insert(trackDbModelToCreate);
      _unitOfWork.Save();

      return trackDbModelToCreate.ConvertToTrackDto();
    }

    public TrackDto Update(TrackDto trackDto)
    {
      if (!_unitOfWork.TrackRepository.Exists(x => x.TrackId == trackDto.TrackId)) return null;

      var trackDbModelToUpdate = trackDto.ConvertToTrackDbModel();

      _unitOfWork.TrackRepository.Update(trackDbModelToUpdate);
      _unitOfWork.Save();

      return trackDbModelToUpdate.ConvertToTrackDto();
    }

    public void Delete(int trackId)
    {
      if (!_unitOfWork.TrackRepository.Exists(x => x.TrackId == trackId)) return;

      _unitOfWork.TrackRepository.Delete(trackId);
      _unitOfWork.Save();
    }

    #region Disposal
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposed)
      {
        if (disposing)
        {
          _unitOfWork.Dispose();
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
