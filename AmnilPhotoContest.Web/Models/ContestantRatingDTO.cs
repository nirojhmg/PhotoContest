using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmnilPhotoContest.Web.Models
{
    public class ContestantRatingDTO
    {
        public int Id { get; set; }
        public int ContestantId { get; set; }
        public string FullName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public string District { get; set; }
        public decimal Rating { get; set; }
        public decimal AverageRating { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime RatedDate { get; set; }
    }
}