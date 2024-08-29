using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiloWellnessMVC.Data.Entities
{
    public class StudentProfileEntity
    {
        [Key]
        public string StudentProfileId { get; set; } = Guid.NewGuid().ToString();  // Auto-generates GUID, gets rid of the annoying null error I keep getting and saves adding a new field on Create.cshtml.

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public int Grade { get; set; }

        [Required]
        public string StudentIdNumber { get; set; }

        [ForeignKey("UserEntity")]
        public string UserId { get; set; }
        public UserEntity User { get; set; }

        // Navigation properties
        public ICollection<VisitEntity> Visits { get; set; }
        public ICollection<WellnessEntity> WellnessRatings { get; set; }
    }
}
