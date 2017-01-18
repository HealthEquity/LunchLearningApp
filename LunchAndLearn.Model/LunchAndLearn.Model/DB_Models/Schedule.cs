using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using LunchAndLearn.Model.DTOs;

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

    public ScheduleDto ConvertToScheduleDto()
    {
      return new ScheduleDto()
      {
        ScheduleId = this.ScheduleId,
        InstructorId = this.InstructorId,
        ClassId = this.ClassId,
        RoomId = this.RoomId,
        TrackId = this.TrackId,
        ClassDate = this.ClassDate
      };
    }

    /// <summary>
    /// Converts a database model to a ScheduleDetailDTO which includes related entities. 
    /// Needs to be used when within scope of a DB context, otherwise related entities will not be loaded and properties will be empty.
    /// </summary>
    /// <returns></returns>
    public ScheduleDetailDto ConvertToScheduleDetailDto()
    {
      return new ScheduleDetailDto()
      {
        ScheduleId = this.ScheduleId,
        ClassDate = this.ClassDate,
        ClassId = this.ClassId,
        ClassName = this.Class?.ClassName ?? "",
        TrackName = this.Track?.TrackName ?? "",
        InstructorId = this.InstructorId,
        InstructorName = this.Instructor?.InstructorName ?? "",
        RoomName = this.Room?.RoomName
      };
    }
  }
}
