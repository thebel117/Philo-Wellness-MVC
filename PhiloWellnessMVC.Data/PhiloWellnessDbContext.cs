using Microsoft.EntityFrameworkCore;
using PhiloWellnessMVC.Models.StudentProfileModels;
using PhiloWellnessMVC.Models.UserModels;
using PhiloWellnessMVC.Models.VisitModels;
using PhiloWellnessMVC.Models.WellnessModels;

namespace PhiloWellnessMVC.Data
{
    public class PhiloWellnessDbContext : DbContext
    {
        public PhiloWellnessDbContext(DbContextOptions<PhiloWellnessDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentProfile> StudentProfiles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<WellnessRating> WellnessRatings { get; set; }
    }
}
