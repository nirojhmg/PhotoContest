using AmnilPhotoContest.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmnilPhotoContest.Concrete
{
    public class DistrictRepository: Repository<District>, IDistrictRepository
    {
        ContestantDbContext _context;
        public DistrictRepository(ContestantDbContext context): base(context)
        {
            _context = context;
        }
    }
}
