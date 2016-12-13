using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearn.Model
{
  [DataContract]
  public class Rating
  {
    [DataMember]
    [Key]
    public int RatingId { get; set; }
    [DataMember]
    public int ClassId { get; set; }
    [DataMember]
    public int ClassRating { get; set; }
    [DataMember]
    public int InstructorId { get; set; }
    [DataMember]
    public int InstructorRating { get; set; }
    [DataMember]
    public string Comment { get; set; }
  }
}
