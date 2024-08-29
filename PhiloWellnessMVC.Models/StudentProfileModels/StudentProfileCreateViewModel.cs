using System.ComponentModel.DataAnnotations;

namespace PhiloWellnessMVC.Models.StudentProfileModels
{
    public class StudentProfileCreateViewModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
        public int UserId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "First Name must be at least 1 character long.")]
        [MaxLength(100, ErrorMessage = "First Name must be no more than 100 characters long.")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "Last Name must be at least 1 character long.")]
        [MaxLength(100, ErrorMessage = "Last Name must be no more than 100 characters long.")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Range(1, 12, ErrorMessage = "Grade must be between 1 and 12.")]
        public int Grade { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Student ID Number must be no more than 50 characters long.")]
        public string StudentIdNumber { get; set; } = string.Empty;
    }
}
