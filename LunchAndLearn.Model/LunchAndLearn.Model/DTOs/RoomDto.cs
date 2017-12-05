using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Model.DTOs
{
  public class RoomDto
  {
    public int RoomId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public byte? MaxOccupancy { get; set; }
    public Room ConvertToRoomDbModel()
    {
      return new Room
      {
        RoomId = this.RoomId,
        Name = this.Name,
        Description = this.Description,
        MaxOccupancy = this.MaxOccupancy
      };
    }
  }
}
