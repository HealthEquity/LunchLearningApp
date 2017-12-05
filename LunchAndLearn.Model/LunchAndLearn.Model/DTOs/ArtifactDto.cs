using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchAndLearn.Model.DB_Models;

namespace LunchAndLearn.Model.DTOs
{
  public class ArtifactDto
  {
    public int ArtifactId { get; set; }
    public string FilePath { get; set; }
    public Artifact ConvertToArtifactDbModel()
    {
      return new Artifact
      {
        ArtifactId = this.ArtifactId,
        FilePath = this.FilePath
      };
    }
  }
}
