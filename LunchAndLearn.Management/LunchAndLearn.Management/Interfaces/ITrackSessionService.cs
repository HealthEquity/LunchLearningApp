using System.Collections.Generic;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Management.Interfaces
{
  public interface ITrackSessionService : IBaseService<TrackSessionDto>
  {
    List<TrackSessionDetailDto> GetUpcoming();
  }
}