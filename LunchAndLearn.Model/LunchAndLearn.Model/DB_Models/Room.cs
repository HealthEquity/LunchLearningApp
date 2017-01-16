using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Model.DB_Models
{
  [DataContract]
  public class Room
  {
    [DataMember]
    [Key]
    public int RoomId { get; set; }
    [DataMember]
    public string RoomName { get; set; }
    [DataMember]
    public string RoomDescription { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; }

    public RoomDto ConvertToRoomDto()
    {
      return new RoomDto()
      {
        RoomId = this.RoomId,
        RoomName = this.RoomName,
        RoomDescription = this.RoomDescription
      };
    }
  }
}
