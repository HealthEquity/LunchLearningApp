using System.Collections.Generic;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Management.Interfaces
{
  public interface ISessionAttendeeService : IBaseService<SessionAttendeeDto>
  {
    void Enroll(int trackSessionId, int attendeeId);
  }
}