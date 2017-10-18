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
    public string RoomName { get; set; }
    public string RoomDescription { get; set; }
    public ushort MaxOccupants { get; set; }

    public Room ConvertToRoomDbModel()
    {
      return new Room()
      {
        RoomId = this.RoomId,
        RoomName = this.RoomName,
        RoomDescription = this.RoomDescription,
        MaxOccupants = this.MaxOccupants,
      };
    }
  }
}
