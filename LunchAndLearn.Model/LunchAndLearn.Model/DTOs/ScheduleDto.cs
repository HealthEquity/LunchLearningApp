using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Model.DB_Models;

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

    public Schedule ConvertToScheduleDbModel()
    {
      return new Schedule()
      {
        ScheduleId = this.ScheduleId,
        InstructorId = this.InstructorId,
        ClassId = this.ClassId,
        RoomId = this.RoomId,
        TrackId = this.TrackId,
        ClassDate = this.ClassDate
      };
    }
  }
}
