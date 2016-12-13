using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearn.Model
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
  }
}
