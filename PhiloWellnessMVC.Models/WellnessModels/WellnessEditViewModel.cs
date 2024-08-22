using System;
using System.ComponentModel.DataAnnotations;

namespace PhiloWellnessMVC.Models.WellnessModels
{
    public class WellnessEditViewModel
    {
        [Required]
        public int WellnessId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Self Rating must be between 1 and 20.")]
        public int SelfRating { get; set; } // 1-20 scale

        [Required]
        [Range(1, 20, ErrorMessage = "Faculty Rating must be between 1 and 20.")]
        public int FacultyRating { get; set; } // 1-20 scale

        [MaxLength(2000, ErrorMessage = "Incidents cannot exceed 2000 characters.")]
        public string? Incidents { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
