using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiloWellnessMVC.Data.Entities
{
    public class UserEntity
    {
        [Key]
        required public string UserId { get; set; }

        [Required,MaxLength(100)]
        public required string FirstName { get; set; }

        [Required, MaxLength(100)]
        public required string LastName { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public required string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public required string Role { get; set; } // For example: "Student" or "Faculty"

        // Navigation properties
        public ICollection<VisitEntity>? Visits { get; set; }
        public ICollection<WellnessEntity>? WellnessRatings { get; set; }
    }
}
