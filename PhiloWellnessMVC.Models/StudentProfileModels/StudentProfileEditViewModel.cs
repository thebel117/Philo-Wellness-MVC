using System.ComponentModel.DataAnnotations;

namespace PhiloWellnessMVC.Models.StudentProfileModels
{
    public class StudentProfileEditViewModel
    {
        [Required]
        public string StudentProfileId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }


        [Required]
        public string UserId { get; set; }

        [Range(1, 12, ErrorMessage = "Grade must be between 1 and 12.")]
        public int Grade { get; set; }

        [StringLength(50, ErrorMessage = "Student ID Number cannot exceed 50 characters.")]
        required public string StudentIdNumber { get; set; }

    }
}
