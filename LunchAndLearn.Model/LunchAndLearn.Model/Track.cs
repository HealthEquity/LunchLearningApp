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
  public class Track
  {
    [DataMember]
    [Key]
    public int TrackId { get; set; }
    [DataMember]
    public string TrackName { get; set; }
    [DataMember]
    public string TrackDescription { get; set; }
    [DataMember]
    public bool IsActive { get; set; }
  }
}
