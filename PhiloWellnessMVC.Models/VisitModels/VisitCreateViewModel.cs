using System;
using System.ComponentModel.DataAnnotations;

namespace PhiloWellnessMVC.Models.VisitModels
{
    public class VisitCreateViewModel
    {
        [Required]
        public string? UserId { get; set; }

        [Required]
        public DateTime VisitDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(255, ErrorMessage = "Reason for visit cannot exceed 255 characters.")]
        public string ReasonForVisit { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "Detailed reason cannot exceed 255 characters.")]
        public string? DetailedReason { get; set; }
    }
}
