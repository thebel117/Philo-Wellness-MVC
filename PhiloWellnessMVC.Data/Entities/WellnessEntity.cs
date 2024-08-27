using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiloWellnessMVC.Data.Entities
{
    public class WellnessEntity
    {
        [Key]
        public string? WellnessId { get; set; }

        [Required]
        public DateTime DateRecorded { get; set; }

        [Required, Range(1, 20)]
        public int SelfRating { get; set; }

        [Required,  Range(1, 20)]
        public int FacultyRating { get; set; }

        public string? IncidentNotes { get; set; }

        // Foreign key for StudentProfile
        [ForeignKey("StudentProfileEntity")]
        public string? StudentProfileId { get; set; }
        public StudentProfileEntity? StudentProfile { get; set; }
            
        [ForeignKey("UserEntity")]
        public string? UserId { get; set; }
        public UserEntity? User { get; set; }
    }
}
