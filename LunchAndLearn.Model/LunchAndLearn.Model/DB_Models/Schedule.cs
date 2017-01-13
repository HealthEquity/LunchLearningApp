using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LunchAndLearn.Model.DB_Models
{
  [DataContract]
  public class Schedule
  {
    [DataMember]
    [Key]
    public int ScheduleId { get; set; }
    [DataMember]
    public int ClassId { get; set; }
    [DataMember]
    public int InstructorId { get; set; }
    [DataMember]
    public int TrackId { get; set; }
    [DataMember]
    public DateTime ClassDate { get; set; }
    [DataMember]
    public int RoomId { get; set; }

    public virtual Class Class { get; set; }
    public virtual Instructor Instructor { get; set; }
    public virtual Track Track { get; set; }
    public virtual Room Room { get; set; }
  }
}
