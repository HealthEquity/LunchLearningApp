using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LunchAndLearn.Model.DB_Models
{
  [DataContract]
  public class Class
  {
    [DataMember]
    [Key]
    public int ClassId { get; set; }

    [DataMember]
    public string ClassName { get; set; }
    [DataMember]
    public string ClassDescription { get; set; }
  }
}
