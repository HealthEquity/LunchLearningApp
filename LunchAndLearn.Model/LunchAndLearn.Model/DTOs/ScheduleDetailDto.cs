using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearn.Model.DTOs
{
  public class ScheduleDetailDto
  {
    public DateTime ClassDate { get; set; }
    public string ClassName { get; set; }
    public int ClassId { get; set; }
    public string TrackName { get; set; }
    public string InstructorName { get; set; }
    public string RoomName { get; set; }
  }
}
