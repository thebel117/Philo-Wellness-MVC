using PhiloWellnessMVC.Models.StudentProfileModels;

namespace PhiloMVC.Services.StudentProfiles
{
    public interface IStudentProfileService
    {
        Task<IEnumerable<StudentProfileIndexViewModel>> GetAllStudentProfilesAsync();
        Task<StudentProfileDetailViewModel> GetStudentProfileByIdAsync(int id);
        Task<bool> CreateStudentProfileAsync(StudentProfileCreateViewModel model);
        Task<bool> UpdateStudentProfileAsync(StudentProfileEditViewModel model);
    }
}
