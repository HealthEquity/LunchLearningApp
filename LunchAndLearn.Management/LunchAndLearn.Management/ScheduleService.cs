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
      using (_scheduleRepository)
      {
        return _scheduleRepository.Get(id).ConvertToScheduleDto();
      }
    }

    public List<ScheduleDto> GetAll()
    {
      using (_scheduleRepository)
      {
        var scheduleList = _scheduleRepository.GetAll().ToList();
        return scheduleList.Select(x => x.ConvertToScheduleDto()).ToList();
      }
    }

    public ScheduleDto Create(ScheduleDto entity)
    {
      using (_scheduleRepository)
      {
        var entityToBeCreated = entity.ConvertToScheduleDbModel();

        _scheduleRepository.Create(entityToBeCreated);
        _scheduleRepository.SaveChanges();

        return entityToBeCreated.ConvertToScheduleDto();
      }
    }

    public ScheduleDto Update(ScheduleDto entity)
    {
      using (_scheduleRepository)
      {
        var entityToBeUpdated = entity.ConvertToScheduleDbModel();

        _scheduleRepository.Update(entityToBeUpdated);
        _scheduleRepository.SaveChanges();

        return entityToBeUpdated.ConvertToScheduleDto();
      }
    }

    public void Delete(int id)
    {
      using (_scheduleRepository)
      {
        _scheduleRepository.Delete(id);
        _scheduleRepository.SaveChanges();
      }
    }

    public List<ScheduleDetailDto> GetScheduleDetailsForSpecificDate(DateTime searchStartDate)
    {
      using (_scheduleRepository)
      {
        var searchEndDate = searchStartDate.Date.AddDays(1);
        var scheduleCollection = _scheduleRepository.GetAll()
          .Where(x => x.ClassDate >= searchStartDate && x.ClassDate < searchEndDate)
          .ToList();

        return scheduleCollection.Select(x => x.ConvertToScheduleDetailDto()).ToList();
      }
    }

    public ScheduleDetailDto GetScheduleDetailsById(int scheduleId)
    {
      using (_scheduleRepository)
      {
        return _scheduleRepository.Get(scheduleId).ConvertToScheduleDetailDto();
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