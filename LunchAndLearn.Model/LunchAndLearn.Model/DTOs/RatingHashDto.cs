using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Model.DTOs
{
  public class RatingHashDto
  {
    public string Value { get; set; }
    public RatingHash ConvertToRatingHashDbModel()
    {
      return new RatingHash
      {
        Value = this.Value
      };
    }
  }
}
