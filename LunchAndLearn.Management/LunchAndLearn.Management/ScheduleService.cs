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
    private readonly IScheduleRepository _scheduleRepository;

    public ScheduleService(IScheduleRepository scheduleRepository)
    {
      _scheduleRepository = scheduleRepository;
    }

    public ScheduleDto Get(int id)
    {
      Schedule schedule;
      using (_scheduleRepository)
      {
        schedule = _scheduleRepository.Get(id);
      }

      return schedule?.ConvertToScheduleDto();
    }

    public List<ScheduleDto> GetAll()
    {
      using (_scheduleRepository)
      {
        var scheduleList = _scheduleRepository.GetAll().ToList();
        return scheduleList.Select(x => x.ConvertToScheduleDto()).ToList();
      }
    }

    public ScheduleDto Create(ScheduleDto scheduleDto)
    {
      using (_scheduleRepository)
      {
        var scheduleDbModel = scheduleDto.ConvertToScheduleDbModel();

        _scheduleRepository.Create(scheduleDbModel);
        _scheduleRepository.SaveChanges();

        return scheduleDbModel.ConvertToScheduleDto();
      }
    }

    public ScheduleDto Update(ScheduleDto scheduleDto)
    {
      using (_scheduleRepository)
      {
        if (!_scheduleRepository.Exists(x => x.ScheduleId == scheduleDto.ScheduleId)) return null;

        var entityToBeUpdated = scheduleDto.ConvertToScheduleDbModel();

        _scheduleRepository.Update(entityToBeUpdated);
        _scheduleRepository.SaveChanges();

        return entityToBeUpdated.ConvertToScheduleDto();
      }
    }

    public void Delete(int scheduleId)
    {
      using (_scheduleRepository)
      {
        if (!_scheduleRepository.Exists(x => x.ScheduleId == scheduleId)) return;

        _scheduleRepository.Delete(scheduleId);
        _scheduleRepository.SaveChanges();
      }
    }

    public List<ScheduleDetailDto> GetDetailedSchedulesForSpecificDate(DateTime searchStartDate)
    {
      using (_scheduleRepository)
      {
        var searchEndDate = searchStartDate.Date.AddDays(1);
        var scheduleCollection = _scheduleRepository.GetSchedulesWithConditionEagerLoaded(x => x.ClassDate >= searchStartDate && x.ClassDate < searchEndDate)
          .ToList();

        return scheduleCollection.Select(x => x.ConvertToScheduleDetailDto()).ToList();
      }
    }

    public ScheduleDetailDto GetDetailedScheduleById(int scheduleId)
    {
      using (_scheduleRepository)
      {
        var schedule =
          _scheduleRepository.GetSchedulesWithConditionEagerLoaded(x => x.ScheduleId == scheduleId).FirstOrDefault();
        return schedule?.ConvertToScheduleDetailDto();
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
          _scheduleRepository.Dispose();
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