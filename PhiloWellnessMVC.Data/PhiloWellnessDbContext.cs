using Microsoft.EntityFrameworkCore;
using PhiloWellnessMVC.Data.Entities;


namespace PhiloWellnessMVC.Data
{
    public class PhiloWellnessDbContext : DbContext
    {
        public PhiloWellnessDbContext(DbContextOptions<PhiloWellnessDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentProfile> StudentProfiles { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<WellnessRating> WellnessRatings { get; set; }
    }
}
