using System;
using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System.Collections.Generic;
using System.Linq;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Management
{
  public class RoomManager : IRoomService
  {
    private readonly IRoomRepository _roomRepository;

    public RoomManager(IRoomRepository roomRepository)
    {
      _roomRepository = roomRepository;
    }

    public RoomDto Get(int id)
    {
      using (_roomRepository)
      {
        return _roomRepository.Get(id).ConvertToRoomDto();
      }
    }

    public List<RoomDto> GetAll()
    {
      using (_roomRepository)
      {
        var roomList = _roomRepository.GetAll().ToList();
        return roomList.Select(x => x.ConvertToRoomDto()).ToList();
      }
    }

    public int Create(RoomDto entity)
    {
      using (_roomRepository)
      {
        var entityToCreate = entity.ConvertToRoomDbModel();
        _roomRepository.Create(entityToCreate);
        _roomRepository.SaveChanges();
        return entityToCreate.RoomId;
      }
    }

    public void Update(RoomDto entity)
    {
      using (_roomRepository)
      {
        var entityToUpdate = entity.ConvertToRoomDbModel();
        _roomRepository.Update(entityToUpdate);
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