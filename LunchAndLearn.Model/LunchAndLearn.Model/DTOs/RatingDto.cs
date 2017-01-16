using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Model.DTOs
{
  public class RatingDto
  {
    public int RatingId { get; set; }
    public int ClassId { get; set; }
    public int ClassRating { get; set; }
    public int InstructorId { get; set; }
    public int InstructorRating { get; set; }
    public string Comment { get; set; }

    public Rating ConvertToRatingDbModel()
    {
      return new Rating()
      {
        RatingId = this.RatingId,
        InstructorId = this.InstructorId,
        ClassId = this.ClassId,
        ClassRating = this.ClassRating,
        InstructorRating = this.InstructorRating,
        Comment = this.Comment
      };
    }
  }
}
