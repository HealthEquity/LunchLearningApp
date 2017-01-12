using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LunchAndLearn.Model.DB_Models
{
  [DataContract]
  public class Instructor
  {
    [DataMember]
    [Key]
    public int InstructorId { get; set; }

    [DataMember]
    public string InstructorName { get; set; }
    [DataMember]
    public bool IsActive { get; set; }
  }
}
