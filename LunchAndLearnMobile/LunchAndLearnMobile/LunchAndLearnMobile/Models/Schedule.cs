using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearnMobile.Models
{
  public class Schedule
  {
    public int ScheduleId { get; set; }
    public string ClassName { get; set; }
    public DateTime ClassDate { get; set; }
    public int ClassId { get; set; }
    public string TrackName { get; set; }
    public string InstructorName { get; set; }
    public int InstructorId { get; set; }
    public string RoomName { get; set; }
  }
}
