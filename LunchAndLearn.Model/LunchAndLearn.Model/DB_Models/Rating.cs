using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Model.DB_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LunchAndLearn.Rating")]
    public partial class Rating
    {
        public int RatingId { get; set; }

        public int TrackSessionId { get; set; }

        public string Comment { get; set; }

        public int? InstructorScoreNr { get; set; }

        public int? SessionScoreNr { get; set; }

        public virtual TrackSession TrackSession { get; set; }

        public RatingDto ConvertToRatingDto()
        {
            return new RatingDto()
            {
                RatingId = this.RatingId,
                TrackSessionId = this.TrackSessionId,
                Comment = this.Comment,
                InstructorScoreNr = this.InstructorScoreNr,
                SessionScoreNr = this.SessionScoreNr
            };
        }
    }
}
