using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LunchAndLearn.Model
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
