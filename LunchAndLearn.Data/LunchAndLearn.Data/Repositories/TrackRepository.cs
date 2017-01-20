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
  public class TrackRepository : BaseRepository<Track>, ITrackRepository
  {
    //public new IQueryable<Track> GetAll()
    //{
    //  DbContext.Configuration.LazyLoadingEnabled = false;

    //  return DbContext.Tracks
    //    .Include(x => x.Schedules);
    //}
    public override bool Exists(int trackId)
    {
      return base.DbContext.Tracks.Any(x => x.TrackId == trackId);
    }
  }
}
