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
    public string Name { get; set; }
    public int SeasonNr { get; set; }
    public string Description { get; set; }
    public Track ConvertToTrackDbModel()
    {
      return new Track
      {
        TrackId = this.TrackId,
        Name = this.Name,
        SeasonNr = this.SeasonNr,
        Description = this.Description
      };
    }
  }
}
