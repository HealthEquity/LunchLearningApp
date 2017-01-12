using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LunchAndLearn.Model.DB_Models
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
