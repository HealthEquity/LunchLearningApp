using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Model.DB_Models
{
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations.Schema;

  [Table("LunchAndLearn.CourseSession")]
    public partial class CourseSession
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseSession()
        {
            TrackSessions = new HashSet<TrackSession>();
            Artifacts = new HashSet<Artifact>();
        }

        public int CourseSessionId { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrackSession> TrackSessions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artifact> Artifacts { get; set; }

        public CourseSessionDto ConvertToCourseSessionDto()
        {
            return new CourseSessionDto()
            {
                CourseSessionId = this.CourseSessionId,
                CourseId = this.CourseId
            };
        }
    }
}
