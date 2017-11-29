using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Model.DB_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LunchAndLearn.Room")]
    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            TrackSessions = new HashSet<TrackSession>();
        }

        public int RoomId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(400)]
        public string Description { get; set; }

        public byte? MaxOccupancy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrackSession> TrackSessions { get; set; }

        public RoomDto ConvertToRoomDto()
        {
            return new RoomDto()
            {
                RoomId = this.RoomId,
                Description = this.Description,
                Name = this.Name,
                MaxOccupancy = this.MaxOccupancy
            };
        }
    }
}
