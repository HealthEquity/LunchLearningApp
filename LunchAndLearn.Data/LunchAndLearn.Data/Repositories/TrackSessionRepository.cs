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
  public class TrackSessionRepository : BaseRepository<TrackSession>, ITrackSessionRepository
  {
    public List<TrackSession> GetUpcoming()
    {
      var endDate = DateTime.Today.AddDays(5);
      var trackSessions = DbContext.TrackSessions.Where(
        ts => ts.SessionDate > DateTime.Today && ts.SessionDate <= endDate).ToList();
      return trackSessions;
    }
  }
}
