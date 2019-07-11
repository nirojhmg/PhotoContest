using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmnilPhotoContest.Business
{
    public interface IContestantRatingRepository: IRepository<ContestantRating>
    {
        IEnumerable<ContestantRatingModel> GetContestantRating();
    }
}
