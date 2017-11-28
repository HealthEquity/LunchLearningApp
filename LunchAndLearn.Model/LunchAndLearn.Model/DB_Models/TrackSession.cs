namespace LunchAndLearn.Model.DB_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LunchAndLearn.TrackSession")]
    public partial class TrackSession
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrackSession()
        {
            Ratings = new HashSet<Rating>();
            People = new HashSet<Person>();
            People1 = new HashSet<Person>();
        }

        public int TrackSessionId { get; set; }

        [Column(TypeName = "date")]
        public DateTime SessionDate { get; set; }

        public int TrackId { get; set; }

        public int? RoomId { get; set; }

        public int? CourseSessionId { get; set; }

        public bool? IsReady { get; set; }

        public string Note { get; set; }

        public virtual CourseSession CourseSession { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual Room Room { get; set; }

        public virtual Track Track { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> People { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> People1 { get; set; }
    }
}
