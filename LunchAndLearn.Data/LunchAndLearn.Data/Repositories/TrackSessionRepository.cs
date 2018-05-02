using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LunchAndLearn.Data.Interfaces;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data.Repositories
{
  public class TrackSessionRepository : BaseRepository<TrackSession>, ITrackSessionRepository
  {
    private const int numberOfDaysToSearchForUpcoming = 5;

    public List<TrackSession> GetUpcoming()
    {
      var endDate = DateTime.Today.AddDays(numberOfDaysToSearchForUpcoming);
      var trackSessions = DbContext.TrackSessions
        .Include(x => x.Track)
        .Include(x => x.Room)
        .Include(x => x.CourseSession)
        .Include(x => x.CourseSession.Course)
        .Where(ts => ts.SessionDate >= DateTime.Today && ts.SessionDate <= endDate)
        .ToList();
      return trackSessions;
    }
  }
}
