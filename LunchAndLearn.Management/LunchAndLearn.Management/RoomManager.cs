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
    private readonly IRoomRepository _roomRepository;

    public RoomManager(IRoomRepository roomRepository)
    {
      _roomRepository = roomRepository;
    }

    public Room Get(int id)
    {
      using (_roomRepository)
      {
        return _roomRepository.Get(id); 
      }
    }

    public List<Room> GetAll()
    {
      using (_roomRepository)
      {
        return _roomRepository.GetAll().ToList(); 
      }
    }

    public int Create(Room entity)
    {
      using (_roomRepository)
      {
        _roomRepository.Create(entity);
        _roomRepository.SaveChanges();
        return entity.RoomId; 
      }
    }

    public void Update(Room entity)
    {
      using (_roomRepository)
      {
        _roomRepository.Update(entity);
        _roomRepository.SaveChanges(); 
      }
    }

    public void Delete(int id)
    {
      using (_roomRepository)
      {
        _roomRepository.Delete(id);
        _roomRepository.SaveChanges(); 
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
          _roomRepository.Dispose();
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