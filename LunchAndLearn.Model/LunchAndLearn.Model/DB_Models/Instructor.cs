using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using LunchAndLearn.Model.DTOs;

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

    public virtual ICollection<Schedule> Schedules { get; set; }
    public virtual ICollection<Rating> Ratings { get; set; }

    public InstructorDto ConvertToInstructorDto()
    {
      return new InstructorDto()
      {
        InstructorId = this.InstructorId,
        InstructorName = this.InstructorName,
        IsActive = this.IsActive
      };
    }
  }
}
