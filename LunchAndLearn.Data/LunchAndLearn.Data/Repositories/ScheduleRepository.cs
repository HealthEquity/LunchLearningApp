using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data.Repositories
{
  public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
  {
    public new IQueryable<Schedule> GetAll()
    {
      DbContext.Configuration.LazyLoadingEnabled = false;

      return DbContext.Schedules
          .Include(x => x.Class)
          .Include(x => x.Instructor)
          .Include(x => x.Track)
          .Include(x => x.Room);
    }

    public new Schedule Get(int id)
    {
      DbContext.Configuration.LazyLoadingEnabled = false;

      return DbContext.Schedules
        .Include(x => x.Class)
        .Include(x => x.Instructor)
        .Include(x => x.Track)
        .Include(x => x.Room)
        .FirstOrDefault(x => x.ScheduleId == id);
    }
  }
}
