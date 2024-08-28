using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiloWellnessMVC.Data.Entities
{
    public class VisitEntity
    {
        [Key]
        public int VisitId { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        [Required]
        public string? ReasonForVisit { get; set; }

        [StringLength(255, ErrorMessage = "Detailed reason cannot exceed 255 characters.")]
        public string? DetailedReason { get; set; } // Added DetailedReason property

        // Foreign key for StudentProfile
        [ForeignKey("StudentProfileEntity")]
        public string? StudentProfileId { get; set; }
        public StudentProfileEntity StudentProfile { get; set; }

        [ForeignKey("UserEntity")]
        required public string UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
