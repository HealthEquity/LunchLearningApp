using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Model.DTOs
{
  public class PersonDto
  {
    public int PersonId { get; set; }
    public Person ConvertToPersonDbModel()
    {
      return new Person
      {
        PersonId = this.PersonId
      };
    }
  }
}
