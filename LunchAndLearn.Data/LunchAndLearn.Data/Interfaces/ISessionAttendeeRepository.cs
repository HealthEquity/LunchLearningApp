﻿using System.Collections.Generic;
using System.Linq;
using LunchAndLearn.Model.DB_Models;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Data.Interfaces
{
  public interface ISessionAttendeeRepository : IBaseRepository<SessionAttendee>
  {
    List<SessionAttendee> GetByPersonId(int personId);
  }
}