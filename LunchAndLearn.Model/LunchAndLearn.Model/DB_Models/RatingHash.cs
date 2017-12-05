using LunchAndLearn.Model.DTOs;

namespace LunchAndLearn.Model.DB_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LunchAndLearn.RatingHash")]
    public partial class RatingHash
    {
        [Key]
        [StringLength(300)]
        public string Value { get; set; }

        public RatingHashDto ConvertToRatingHashDto()
        {
            return new RatingHashDto()
            {
                Value = this.Value
            };
        }
    }
}
