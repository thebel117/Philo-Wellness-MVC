using System.Collections.Generic;
using System.Threading.Tasks;
using PhiloWellnessMVC.Models.StudentProfileModels;

namespace PhiloWellnessMVC.Services
{
    public interface IStudentProfileService
    {
        Task<IEnumerable<StudentProfileIndexViewModel>> GetAllStudentProfilesAsync();
        Task<StudentProfileDetailViewModel> GetStudentProfileByIdAsync(int studentId);
        Task<bool> CreateStudentProfileAsync(StudentProfileCreateViewModel model);
        Task<bool> UpdateStudentProfileAsync(StudentProfileEditViewModel model);
        Task<bool> DeleteStudentProfileAsync(int studentId);
    }
}
