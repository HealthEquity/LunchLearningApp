using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Model.DB_Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations.Schema;

  [Table("LunchAndLearn.TrackSession")]
  public class TrackSession
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public TrackSession()
    {
      Ratings = new HashSet<Rating>();
      People = new HashSet<Person>();
    }

    public int TrackSessionId { get; set; }

    [Column(TypeName = "date")]
    public DateTime SessionDate { get; set; }

    public int TrackId { get; set; }

    public int? RoomId { get; set; }

    public int? CourseSessionId { get; set; }

    public bool? IsReady { get; set; }

    public string Note { get; set; }

    public virtual CourseSession CourseSession { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Rating> Ratings { get; set; }

    public virtual Room Room { get; set; }

    public virtual Track Track { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Person> People { get; set; }

    public TrackSessionDto ConvertToTrackSessionDto()
    {
      return new TrackSessionDto()
      {
        TrackSessionId = this.TrackSessionId,
        RoomId = this.RoomId,
        CourseSessionId = this.CourseSessionId,
        TrackId = this.TrackId,
        Note = this.Note,
        IsReady = this.IsReady,
        SessionDate = this.SessionDate
      };
    }

    public TrackSessionDetailDto ConvertToTrackSessionDetailDto()
    {
      return new TrackSessionDetailDto
      {
        TrackSessionId = this.TrackSessionId,
        SessionDate = this.SessionDate,
        TrackName = this.Track?.Name ?? "",
        RoomName = this.Room?.Name ?? "",
        RoomDescription = this.Room?.Description ?? "",
        CourseName = this.CourseSession?.Course?.CourseName ?? "",
        IsReady = this.IsReady,
        Note = this.Note
      };
    }
  }
}
