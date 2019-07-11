using AmnilPhotoContest.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmnilPhotoContest.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContestantDbContext context;

        public UnitOfWork(ContestantDbContext _context)
        {
            context = _context;
            District = new DistrictRepository(context);
            Contestant = new ContestantRepository(context);
            ContestantRating = new ContestantRatingRepository(context);
        }

        public IDistrictRepository District { get; private set; }

        public IContestantRepository Contestant { get; private set; }

        public IContestantRatingRepository ContestantRating { get; private set; }

        public void Complete()
        {
            context.SaveChanges();
        }
    }
}
