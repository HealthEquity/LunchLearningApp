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
  public class ScheduleService : IScheduleService
  {
    private readonly IUnitOfWork _unitOfWork;

    public ScheduleService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public ScheduleDto Get(int id)
    {
      return _unitOfWork.ScheduleRepository.GetById(id)?.ConvertToScheduleDto();
    }

    public List<ScheduleDto> GetAll()
    {
      return _unitOfWork.ScheduleRepository.Get().Select(x => x.ConvertToScheduleDto()).ToList();
    }

    public ScheduleDto Create(ScheduleDto scheduleDto)
    {
      var scheduleDbModel = scheduleDto.ConvertToScheduleDbModel();

      _unitOfWork.ScheduleRepository.Insert(scheduleDbModel);
      _unitOfWork.Save();

      return scheduleDbModel.ConvertToScheduleDto();
    }

    public ScheduleDto Update(ScheduleDto scheduleDto)
    {
      if (!_unitOfWork.ScheduleRepository.Exists(x => x.ScheduleId == scheduleDto.ScheduleId)) return null;

      var scheduleDbModelToBeUpdated = scheduleDto.ConvertToScheduleDbModel();

      _unitOfWork.ScheduleRepository.Update(scheduleDbModelToBeUpdated);
      _unitOfWork.Save();

      return scheduleDbModelToBeUpdated.ConvertToScheduleDto();
    }

    public void Delete(int scheduleId)
    {
      if (!_unitOfWork.ScheduleRepository.Exists(x => x.ScheduleId == scheduleId)) return;

      _unitOfWork.ScheduleRepository.Delete(scheduleId);
      _unitOfWork.Save();
    }

    public List<ScheduleDetailDto> GetDetailedSchedulesForSpecificDate(DateTime searchStartDate)
    {
      var searchEndDate = searchStartDate.Date.AddDays(1);
      return
        _unitOfWork.ScheduleRepository.Get(
            filter: x => x.ClassDate >= searchStartDate && x.ClassDate < searchEndDate,
            orderBy: s => s.OrderByDescending(a => a.ClassDate),
            includeProperties: "class,instructor,track,room")
          .Select(x => x.ConvertToScheduleDetailDto())
          .ToList();
    }

    public ScheduleDetailDto GetDetailedScheduleById(int scheduleId)
    {
      return _unitOfWork.ScheduleRepository.GetById(scheduleId)?.ConvertToScheduleDetailDto();
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