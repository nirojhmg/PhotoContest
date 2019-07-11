using AmnilPhotoContest.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmnilPhotoContest.Concrete
{
    public class ContestantRatingRepository: Repository<ContestantRating>, IContestantRatingRepository
    {
        ContestantDbContext _context;
        public ContestantRatingRepository(ContestantDbContext context): base(context)
        {
            _context = context;
        }
        public IEnumerable<ContestantRatingModel> GetContestantRating()
        {
            return _context.Database.SqlQuery<ContestantRatingModel>("SpGetContestantRating");
        }
    }
}
