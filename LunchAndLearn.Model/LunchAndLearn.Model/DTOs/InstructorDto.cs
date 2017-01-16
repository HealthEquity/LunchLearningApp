using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearn.Model.DTOs
{
  public class InstructorDto
  {
    public int InstructorId { get; set; }
    public string InstructorName { get; set; }
    public bool IsActive { get; set; }
  }
}
