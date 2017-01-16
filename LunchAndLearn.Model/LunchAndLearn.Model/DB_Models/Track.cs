using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Model.DB_Models
{
  [DataContract]
  public class Track
  {
    [DataMember]
    [Key]
    public int TrackId { get; set; }
    [DataMember]
    public string TrackName { get; set; }
    [DataMember]
    public string TrackDescription { get; set; }
    [DataMember]
    public bool IsActive { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; }

    public TrackDto ConvertToTrackDto()
    {
      return new TrackDto()
      {
        TrackId = this.TrackId,
        TrackName = this.TrackName,
        TrackDescription = this.TrackDescription,
        IsActive = this.IsActive
      };
    }
  }
}
