using System;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Model.DTOs
{
  public class TrackSessionDto
  {
    public int TrackSessionId { get; set; }
    public DateTime SessionDate { get; set; }
    public int TrackId { get; set; }
    public int? RoomId { get; set; }
    public int? CourseSessionId { get; set; }
    public bool? IsReady { get; set; }
    public string Note { get; set; }
    public TrackSession ConvertToTrackSessionDbModel()
    {
      return new TrackSession
      {
        TrackSessionId = this.TrackSessionId, 
        SessionDate = this.SessionDate,
        TrackId = this.TrackId,
        RoomId = this.RoomId,
        CourseSessionId = this.CourseSessionId,
        IsReady = this.IsReady,
        Note = this.Note
      };
    }
  }
}
