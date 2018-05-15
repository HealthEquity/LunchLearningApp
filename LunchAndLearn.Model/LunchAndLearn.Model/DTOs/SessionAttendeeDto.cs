using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Model.DTOs
{
  public class SessionAttendeeDto
  {
    public int SessionAttendeeId { get; set; }
    public int PersonId { get; set; }
    public int TrackSessionId { get; set; }
    public SessionAttendee ConvertToSessionAttendeeDbModel()
    {
      return new SessionAttendee
      {
        SessionAttendeeId = this.SessionAttendeeId,
        PersonId = this.PersonId,
        TrackSessionId = this.TrackSessionId,
      };
    }
  }
}
