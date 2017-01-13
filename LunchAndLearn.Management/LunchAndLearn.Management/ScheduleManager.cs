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
  public class ScheduleManager : IManagerClass<Schedule>
  {
    private readonly ILunchAndLearnRepository<Schedule> _scheduleRepository;

    public ScheduleManager(ILunchAndLearnRepository<Schedule> scheduleRepository)
    {
      _scheduleRepository = scheduleRepository;
    }

    public Schedule Get(int id)
    {
      return _scheduleRepository.Get(id);
    }

    public List<Schedule> GetAll()
    {
      return _scheduleRepository.GetAll().ToList();
    }

    public int Create(Schedule entity)
    {
      _scheduleRepository.Create(entity);
      _scheduleRepository.SaveChanges();
      return entity.ScheduleId;
    }

    public void Update(Schedule entity)
    {
      _scheduleRepository.Update(entity);
      _scheduleRepository.SaveChanges();
    }

    public void Delete(int id)
    {
      _scheduleRepository.Delete(id);
      _scheduleRepository.SaveChanges();
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