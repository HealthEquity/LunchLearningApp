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
