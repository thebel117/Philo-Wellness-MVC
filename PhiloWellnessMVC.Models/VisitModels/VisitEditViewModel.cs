using System;
using System.ComponentModel.DataAnnotations;

namespace PhiloWellnessMVC.Models.VisitModels
{
    public class VisitEditViewModel
    {
        [Required]
        public int VisitId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        [Required(ErrorMessage = "Reason for visit is required.")]
        [MaxLength(255, ErrorMessage = "Reason for visit cannot exceed 255 characters.")]
        public string? ReasonForVisit { get; set; }

        [MaxLength(255, ErrorMessage = "Detailed reason cannot exceed 255 characters.")]
        public string? DetailedReason { get; set; }
    }
}
