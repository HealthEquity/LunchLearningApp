using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Data.Repositories
{
  public class SessionAttendeeRepository : BaseRepository<SessionAttendee>, ISessionAttendeeRepository
  {
    public List<SessionAttendee> GetByPersonId(int personId)
    {
      var sessionAttendees = DbContext.SessionAttendees.Where(sa => sa.PersonId == personId).ToList();
      return sessionAttendees;
    }
  }
}
