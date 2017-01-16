using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Model.DTOs
{
  public class ClassDto
  {
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public string ClassDescription { get; set; }

    public Class ConvertToClassDbModel()
    {
      return new Class
      {
        ClassId = this.ClassId,
        ClassName = this.ClassName,
        ClassDescription = this.ClassDescription
      };
    }
  }
}
