using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Model.DTOs
{
  public class TrackDto
  {
    public int TrackId { get; set; }
    public string TrackName { get; set; }
    public string TrackDescription { get; set; }
    public bool IsActive { get; set; }

    public Track ConvertToTrackDbModel()
    {
      return new Track()
      {
        TrackId = this.TrackId,
        TrackName = this.TrackName,
        TrackDescription = this.TrackDescription,
        IsActive = this.IsActive
      };
    }
  }
}
