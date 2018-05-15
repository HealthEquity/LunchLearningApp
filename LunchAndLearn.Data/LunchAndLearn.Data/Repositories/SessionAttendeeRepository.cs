using System;
using System.Collections.Generic;
using System.Data.Entity;
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
  }
}
