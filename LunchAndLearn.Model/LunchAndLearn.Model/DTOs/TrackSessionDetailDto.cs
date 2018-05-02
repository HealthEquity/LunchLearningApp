using System;

namespace LunchAndLearn.Model.DTOs
{
  public class TrackSessionDetailDto
  {
    public int TrackSessionId { get; set; }
    public DateTime SessionDate { get; set; }
    public string TrackName { get; set; }
    public string RoomName { get; set; }
    public string CourseName { get; set; }
    public bool? IsReady { get; set; }
    public string Note { get; set; }
  }
}