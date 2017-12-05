using LunchAndLearn.Data;
using LunchAndLearn.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
  public class CourseSessionService : ICourseSessionService
  {
    private readonly ICourseSessionRepository _courseSessionRepository;

    public CourseSessionService(ICourseSessionRepository courseSessionRepository)
    {
      _courseSessionRepository = courseSessionRepository;
    }

    public CourseSessionDto Get(int id)
    {
      using (_courseSessionRepository)
      {
        var retrievedCourseSession = _courseSessionRepository.Get(id);
        return retrievedCourseSession.ConvertToCourseSessionDto();
      }
    }

    public List<CourseSessionDto> GetAll()
    {
      using (_courseSessionRepository)
      {
        var ClassSessions = _courseSessionRepository.GetAll().ToList();
        return ClassSessions.Select(x => x.ConvertToCourseSessionDto()).ToList();
      }
    }

    public CourseSessionDto Create(CourseSessionDto entity)
    {
      using (_courseSessionRepository)
      {
        var entityToCreate = entity.ConvertToCourseSessionDbModel();

        _courseSessionRepository.Create(entityToCreate);
        _courseSessionRepository.SaveChanges();

        return entityToCreate.ConvertToCourseSessionDto();
      }
    }

    public CourseSessionDto Update(CourseSessionDto entity)
    {
      using (_courseSessionRepository)
      {
        var entityToUpdate = entity.ConvertToCourseSessionDbModel();

        _courseSessionRepository.Update(entityToUpdate);
        _courseSessionRepository.SaveChanges();

        return entityToUpdate.ConvertToCourseSessionDto();
      }
    }

    public void Delete(int id)
    {
      using (_courseSessionRepository)
      {
        _courseSessionRepository.Delete(id);
        _courseSessionRepository.SaveChanges(); 
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
          _courseSessionRepository.Dispose();
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
