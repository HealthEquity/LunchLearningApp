using System;
using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System.Collections.Generic;
using System.Linq;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Management
{
  public class RoomManager : IManagerClass<Room>
  {
    private readonly ILunchAndLearnRepository<Room> _lunchAndLearnRepository;

    public RoomManager(ILunchAndLearnRepository<Room> lunchAndLearnRepository)
    {
      _lunchAndLearnRepository = lunchAndLearnRepository;
    }

    public Room Get(int id)
    {
      return _lunchAndLearnRepository.Get(id);
    }

    public List<Room> GetAll()
    {
      return _lunchAndLearnRepository.GetAll().ToList();
    }

    public int Create(Room entity)
    {
      _lunchAndLearnRepository.Create(entity);
      _lunchAndLearnRepository.SaveChanges();
      return entity.RoomId;
    }

    public void Update(Room entity)
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