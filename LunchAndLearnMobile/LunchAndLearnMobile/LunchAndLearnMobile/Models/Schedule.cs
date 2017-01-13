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
    public string ClassDescription { get; set; }
    public string InstructorName { get; set; }
    public string RoomName { get; set; }
  }
}
