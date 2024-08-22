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

        // Foreign key for StudentProfile
        [ForeignKey("StudentProfileEntity")]
        public int StudentProfileId { get; set; }
        public StudentProfileEntity? StudentProfile { get; set; }
    }
}
