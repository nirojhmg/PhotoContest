using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmnilPhotoContest.Business
{
    public class ContestantRating
    {
        public int Id { get; set; }
        public int ContestantId { get; set; }
        public decimal Rating { get; set; }
        public DateTime RatedDate { get; set; }
    }
}
