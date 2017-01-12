using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

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
  }
}
