using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data.Repositories
{
  public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
  {
    public List<Schedule> GetSchedulesWithConditionEagerLoaded(Expression<Func<Schedule, bool>> whereExpression)
    {
      DbContext.Configuration.LazyLoadingEnabled = false;

      return DbContext.Schedules
        .Include(x => x.Class)
        .Include(x => x.Instructor)
        .Include(x => x.Track)
        .Include(x => x.Room)
        .Where(whereExpression)
        .ToList();
    }

    public override bool Exists(int scheduleId)
    {
      return base.DbContext.Schedules.Any(x => x.ScheduleId == scheduleId);
    }
  }
}
