using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearn.Model.DTOs
{
  public class ScheduleDto
  {
    public int ScheduleId { get; set; }
    public int ClassId { get; set; }
    public int InstructorId { get; set; }
    public int TrackId { get; set; }
    public DateTime ClassDate { get; set; }
    public int RoomId { get; set; }
  }
}
