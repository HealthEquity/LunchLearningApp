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
  public class SessionAttendeeService : ISessionAttendeeService
  {
    private readonly ISessionAttendeeRepository _sessionAttendeeRepository;

    public SessionAttendeeService(ISessionAttendeeRepository sessionAttendeeRepository)
    {
      _sessionAttendeeRepository = sessionAttendeeRepository;
    }

    public SessionAttendeeDto Get(int id)
    {
      using (_sessionAttendeeRepository)
      {
        return _sessionAttendeeRepository.Get(id).ConvertToSessionAttendeeDto(); 
      }
    }

    public List<SessionAttendeeDto> GetAll()
    {
      using (_sessionAttendeeRepository)
      {
        var sessionAttendeeList =_sessionAttendeeRepository.GetAll().ToList();
        return sessionAttendeeList.Select(x => x.ConvertToSessionAttendeeDto()).ToList();
      }
    }

    public List<SessionAttendeeDto> GetByPersonId(int personId)
    {
      using (_sessionAttendeeRepository)
      {
        var sessionAttendeeList = _sessionAttendeeRepository.GetAll().ToList();
        return sessionAttendeeList.Select(x => x.ConvertToSessionAttendeeDto()).ToList();
      }
    }

    public SessionAttendeeDto Create(SessionAttendeeDto entity)
    {
      using (_sessionAttendeeRepository)
      {
        var entityToCreate = entity.ConvertToSessionAttendeeDbModel();

        _sessionAttendeeRepository.Create(entityToCreate);
        _sessionAttendeeRepository.SaveChanges();

        return entityToCreate.ConvertToSessionAttendeeDto();
      }
    }

    public void Enroll(int trackSessionId, int attendeeId)
    {
      var sessionAttendee = new SessionAttendee()
      {
        TrackSessionId = trackSessionId,
        PersonId = attendeeId
      };
      using (_sessionAttendeeRepository)
      {
        _sessionAttendeeRepository.Create(sessionAttendee);
      }
    }

    public SessionAttendeeDto Update(SessionAttendeeDto entity)
    {
      using (_sessionAttendeeRepository)
      {
        var entityToUpdate = entity.ConvertToSessionAttendeeDbModel();

        _sessionAttendeeRepository.Update(entityToUpdate);
        _sessionAttendeeRepository.SaveChanges();

        return entityToUpdate.ConvertToSessionAttendeeDto();
      }
    }

    public void Delete(int id)
    {
      using (_sessionAttendeeRepository)
      {
        _sessionAttendeeRepository.Delete(id);
        _sessionAttendeeRepository.SaveChanges(); 
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
          _sessionAttendeeRepository.Dispose();
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
