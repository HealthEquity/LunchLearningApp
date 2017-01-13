using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data.Interfaces
{
  public interface IScheduleRepository : IBaseRepository<Schedule>
  {
    new IQueryable<Schedule> GetAll();
  }
}