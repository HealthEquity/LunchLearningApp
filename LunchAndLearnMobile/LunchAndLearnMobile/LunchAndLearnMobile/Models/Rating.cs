using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearnMobile.Models
{
  public class Rating
  {
    public int RatingId { get; set; }
    public int ClassId { get; set; }
    public int ClassRating { get; set; }
    public int InstructorId { get; set; }
    public int InstructorRating { get; set; }
    public string Comment { get; set; }
  }
}
