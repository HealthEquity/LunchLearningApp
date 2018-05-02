using System.Collections.Generic;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Data.Interfaces
{
  public interface ITrackSessionRepository : IBaseRepository<TrackSession>
  {
    List<TrackSession> GetUpcoming();
  }
}