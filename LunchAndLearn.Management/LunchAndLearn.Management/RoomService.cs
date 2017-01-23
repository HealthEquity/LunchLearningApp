using System;
using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Data.Repositories;
using LunchAndLearn.Management.Interfaces;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Management
{
  public class RoomService : IRoomService
  {
    private readonly IUnitOfWork _unitOfWork;

    public RoomService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public RoomDto Get(int roomId)
    {
      return _unitOfWork.RoomRepository.GetById(roomId)?.ConvertToRoomDto();
    }

    public List<RoomDto> GetAll()
    {
      return _unitOfWork.RoomRepository.Get().Select(x => x.ConvertToRoomDto()).ToList();
    }

    public RoomDto Create(RoomDto roomDto)
    {
      var entityToCreate = roomDto.ConvertToRoomDbModel();

      _unitOfWork.RoomRepository.Insert(entityToCreate);
      _unitOfWork.Commit();

      return entityToCreate.ConvertToRoomDto();
    }

    public RoomDto Update(RoomDto roomDto)
    {
      if (!_unitOfWork.RoomRepository.Exists(x => x.RoomId == roomDto.RoomId)) return null;

      var roomDbModelToUpdate = roomDto.ConvertToRoomDbModel();

      _unitOfWork.RoomRepository.Update(roomDbModelToUpdate);
      _unitOfWork.Commit();

      return roomDbModelToUpdate.ConvertToRoomDto();
    }

    public void Delete(int roomId)
    {
      if (!_unitOfWork.RoomRepository.Exists(x => x.RoomId == roomId)) return;

      _unitOfWork.RoomRepository.Delete(roomId);
      _unitOfWork.Commit();
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