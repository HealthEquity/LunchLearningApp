using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Model.DB_Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations.Schema;

  [Table("LunchAndLearn.SessionAttendee")]
  public class SessionAttendee
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public int SessionAttendeeId { get; set; }
    public int TrackSessionId { get; set; }

    public int PersonId { get; set; }

    public SessionAttendeeDto ConvertToSessionAttendeeDto()
    {
      return new SessionAttendeeDto()
      {
        SessionAttendeeId = this.SessionAttendeeId,
        TrackSessionId = this.TrackSessionId,
        PersonId = this.PersonId
      };
    }
  }
}
