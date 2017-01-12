using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LunchAndLearn.Model.DB_Models
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
