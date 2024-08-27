using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiloWellnessMVC.Data.Entities
{
    public class WellnessEntity
    {
        [Key]
        public int WellnessId { get; set; }

        [Required]
        public DateTime DateRecorded { get; set; }

        [Required, Range(1, 20)]
        public int SelfRatedWellness { get; set; }

        [Required,  Range(1, 20)]
        public int FacultyPerceivedWellness { get; set; }

        public string? IncidentNotes { get; set; }

        // Foreign key for StudentProfile
        [ForeignKey("StudentProfileEntity")]
        public int StudentProfileId { get; set; }
        public StudentProfileEntity? StudentProfile { get; set; }
            
        [ForeignKey("UserEntity")]
        public string? UserId { get; set; }
        public UserEntity? User { get; set; }
    }
}
