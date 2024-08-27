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

        public virtual DbSet<StudentProfileEntity> StudentProfiles { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<VisitEntity> Visits { get; set; }
        public virtual DbSet<WellnessEntity> WellnessRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships and constraints if needed

            // Example configuration
            modelBuilder.Entity<VisitEntity>()
                .HasOne(v => v.StudentProfile)
                .WithMany(sp => sp.Visits)
                .HasForeignKey(v => v.StudentProfileId);

            modelBuilder.Entity<VisitEntity>()
                .HasOne(v => v.User)
                .WithMany(u => u.Visits)
                .HasForeignKey(v => v.UserId);

            modelBuilder.Entity<WellnessEntity>()
                .HasOne(w => w.StudentProfile)
                .WithMany(sp => sp.WellnessRatings)
                .HasForeignKey(w => w.StudentProfileId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust as necessary

            modelBuilder.Entity<WellnessEntity>()
                .HasOne(w => w.User)
                .WithMany(u => u.WellnessRatings)
                .HasForeignKey(w => w.UserId);
        }
    }
}
