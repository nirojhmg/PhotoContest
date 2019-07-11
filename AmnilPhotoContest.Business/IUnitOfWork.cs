using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmnilPhotoContest.Business
{
    public interface IUnitOfWork
    {
        IDistrictRepository District { get; }
        IContestantRepository Contestant { get; }
        IContestantRatingRepository ContestantRating { get; }
        void Complete();
    }
}
