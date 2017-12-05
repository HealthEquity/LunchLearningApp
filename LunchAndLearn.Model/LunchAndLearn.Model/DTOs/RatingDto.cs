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
    public int TrackSessionId { get; set; }
    public string Comment { get; set; }
    public int? InstructorScoreNr { get; set; }
    public int? SessionScoreNr { get; set; }
    public Rating ConvertToRatingDbModel()
    {
      return new Rating
      {
        RatingId = this.RatingId,
        TrackSessionId = this.TrackSessionId,
        Comment = this.Comment,
        InstructorScoreNr = this.InstructorScoreNr,
        SessionScoreNr = this.SessionScoreNr
      };
    }
  }
}
