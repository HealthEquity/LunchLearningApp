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
  public class RatingRepository : BaseRepository<Rating>, IRatingRepository
  {
    public new IQueryable<Rating> GetAll()
    {
      DbContext.Configuration.LazyLoadingEnabled = false;

      return DbContext.Ratings
        .Include(x => x.Class)
        .Include(x => x.Instructor);
    }
  }
}
