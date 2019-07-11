using AmnilPhotoContest.Business;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmnilPhotoContest.Concrete
{
    public class ContestantDbContext: DbContext
    {
        public ContestantDbContext(): base("name=ContestantDbContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>().ToTable("District");
            modelBuilder.Entity<Contestant>().ToTable("Contestant");
            modelBuilder.Entity<ContestantRating>().ToTable("ContestantRating");
        }

        public DbSet<District> Districts { get; set; }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<ContestantRating> ContestantRatings { get; set; }
    }
}
