using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearn.Model.DTOs
{
  public class TrackDto
  {
    public int TrackId { get; set; }
    public string TrackName { get; set; }
    public string TrackDescription { get; set; }
    public bool IsActive { get; set; }
  }
}
