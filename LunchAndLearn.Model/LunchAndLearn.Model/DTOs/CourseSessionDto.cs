using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Model.DTOs
{
  public class CourseSessionDto
  {
    public int CourseSessionId { get; set; }
    public int CourseId { get; set; }
    public CourseSession ConvertToCourseSessionDbModel()
    {
      return new CourseSession
      {
        CourseSessionId = this.CourseSessionId,
        CourseId = this.CourseId
      };
    }
  }
}
