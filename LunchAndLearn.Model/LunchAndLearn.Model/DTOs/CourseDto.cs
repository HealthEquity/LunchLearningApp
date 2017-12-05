using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Model.DTOs
{
  public class CourseDto
  {
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public string CourseDescription { get; set; }
    public Course ConvertToCourseDbModel()
    {
      return new Course
      {
        CourseId = this.CourseId,
        CourseName = this.CourseName,
        CourseDescription = this.CourseDescription
      };
    }
  }
}
