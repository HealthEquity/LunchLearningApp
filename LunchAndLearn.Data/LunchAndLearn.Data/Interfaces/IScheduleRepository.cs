using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data.Interfaces
{
  public interface IScheduleRepository : IBaseRepository<Schedule>
  {
    List<Schedule> GetSchedulesWithConditionEagerLoaded(Expression<Func<Schedule, bool>> whereExpression);
  }
}