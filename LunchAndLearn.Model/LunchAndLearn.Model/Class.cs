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
