using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmnilPhotoContest.Business
{
    public interface IContestantRepository: IRepository<Contestant>
    {
        IEnumerable<Contestant> GetWithPagination(int pageIndex, int pageSize);
    }
}
