using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Model.DB_Models
{
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  [Table("LunchAndLearn.Course")]
  public class Course
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Course()
    {
      CourseSessions = new HashSet<CourseSession>();
      People = new HashSet<Person>();
    }

    public int CourseId { get; set; }

    [Required]
    [StringLength(100)]
    public string CourseName { get; set; }

    [StringLength(400)]
    public string CourseDescription { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<CourseSession> CourseSessions { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Person> People { get; set; }

    public CourseDto ConvertToCourseDto()
    {
      return new CourseDto()
      {
        CourseId = this.CourseId,
        CourseName = this.CourseName,
        CourseDescription = this.CourseDescription
      };
    }
  }
}
