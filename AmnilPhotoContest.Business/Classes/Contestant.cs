using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmnilPhotoContest.Business
{
    public class Contestant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public int DistrictId { get; set; }
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }
        public string Address { get; set; }
    }
}
