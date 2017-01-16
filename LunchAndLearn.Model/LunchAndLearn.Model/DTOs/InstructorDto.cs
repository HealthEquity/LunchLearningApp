using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Model.DTOs
{
  public class InstructorDto
  {
    public int InstructorId { get; set; }
    public string InstructorName { get; set; }
    public bool IsActive { get; set; }

    public Instructor ConvertToInstructorDbModel()
    {
      return new Instructor()
      {
        InstructorId = this.InstructorId,
        InstructorName = this.InstructorName,
        IsActive = this.IsActive
      };
    }
  }
}
