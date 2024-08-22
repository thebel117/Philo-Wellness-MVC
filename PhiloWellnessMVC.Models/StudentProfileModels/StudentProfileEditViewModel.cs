using System.ComponentModel.DataAnnotations;

namespace PhiloWellnessMVC.Models.StudentProfileModels
{
    public class StudentProfileEditViewModel
    {
        [Required]
        public int StudentProfileId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Range(1, 12, ErrorMessage = "Grade must be between 1 and 12.")]
        public int Grade { get; set; }

        [StringLength(50, ErrorMessage = "Student ID Number cannot exceed 50 characters.")]
        public string? StudentIdNumber { get; set; }
    }
}
