using AmnilPhotoContest.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmnilPhotoContest.Concrete
{
    public class ContestantRepository: Repository<Contestant>, IContestantRepository
    {
        ContestantDbContext _context;
        public ContestantRepository(ContestantDbContext context): base(context)
        {
            _context = context;
        }

        public IEnumerable<Contestant> GetWithPagination(int pageIndex, int pageSize)
        {
            return _context.Contestants
                .OrderBy(c => c.FirstName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).ToList();
        }
    }
}
