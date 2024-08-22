using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiloWellnessMVC.Data.Entities
{
    public class StudentProfileEntity
    {
        [Key]
        public int StudentProfileId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? LastName { get; set; }

        [Required]
        public int Grade { get; set; }

        [Required]
        public int StudentIdNumber { get; set; }

        // Navigation properties
        public ICollection<VisitEntity>? Visits { get; set; }
        public ICollection<WellnessEntity>? WellnessRatings { get; set; }
    }
}
