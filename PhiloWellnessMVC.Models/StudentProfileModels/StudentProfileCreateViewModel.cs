using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhiloWellnessMVC.Models.StudentProfileModels
{
    public class StudentProfileCreateViewModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
        public int UserId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Name must be at least 1 character long.")]
        [MaxLength(255, ErrorMessage = "Name must be no more than 255 characters long.")]
        required public string Name { get; set; } = string.Empty;

        [Range(1, 12, ErrorMessage = "Grade must be between 1 and 12.")]
        public int Grade { get; set; }

        [MaxLength(50, ErrorMessage = "Student ID Number must be no more than 50 characters long.")]
        required public string StudentIdNumber { get; set; }
    }
}
