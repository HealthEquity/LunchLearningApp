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
  public class ClassRepository : BaseRepository<Class>, IClassRepository
  {
    public new IQueryable<Class> GetAll()
    {
      DbContext.Configuration.LazyLoadingEnabled = false;

      return DbContext.Classes
        .Include(x => x.Schedules)
        .Include(x => x.Ratings);
    }
  }
}
