using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmnilPhotoContest.Business
{
    public class ContestantRatingModel
    {
        public int ContestantId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string District { get; set; }
        public decimal AverageRating { get; set; }
        public string PhotoUrl { get; set; }
    }
}
