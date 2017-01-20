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
  public class InstructorRepository : BaseRepository<Instructor>, IInstructorRepository
  {
    //public new IQueryable<Instructor> GetAll()
    //{
    //  DbContext.Configuration.LazyLoadingEnabled = false;

    //  return DbContext.Instructors
    //    .Include(x => x.Schedules)
    //    .Include(x => x.Ratings);
    //}
    public override bool Exists(int instructorId)
    {
      return base.DbContext.Instructors.Any(x => x.InstructorId == instructorId);
    }
  }
}
