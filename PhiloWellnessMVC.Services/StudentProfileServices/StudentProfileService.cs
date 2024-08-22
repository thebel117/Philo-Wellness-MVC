using Microsoft.EntityFrameworkCore;
using PhiloWellnessMVC.Data;
using PhiloWellnessMVC.Models.StudentProfileModels;
using AutoMapper;

namespace PhiloWellnessMVC.Services.StudentProfiles
{
    public class StudentProfileService : IStudentProfileService
    {
        private readonly PhiloWellnessDbContext _context;
        private readonly IMapper _mapper;

        public StudentProfileService(PhiloWellnessDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentProfileIndexViewModel>> GetAllStudentProfilesAsync()
        {
            var studentProfiles = await _context.StudentProfiles.Include(sp => sp.User).ToListAsync();
            return _mapper.Map<IEnumerable<StudentProfileIndexViewModel>>(studentProfiles);
        }

        public async Task<StudentProfileDetailViewModel> GetStudentProfileByIdAsync(int id)
        {
            var studentProfile = await _context.StudentProfiles
                .Include(sp => sp.User)
                .Include(sp => sp.Visits)
                .Include(sp => sp.WellnessRecords)
                .FirstOrDefaultAsync(sp => sp.StudentProfileId == id);

            if (studentProfile == null) return null;

            return _mapper.Map<StudentProfileDetailViewModel>(studentProfile);
        }

        public async Task<bool> CreateStudentProfileAsync(StudentProfileCreateViewModel model)
        {
            var studentProfile = _mapper.Map<StudentProfile>(model);
            _context.StudentProfiles.Add(studentProfile);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStudentProfileAsync(StudentProfileEditViewModel model)
        {
            var existingProfile = await _context.StudentProfiles.FindAsync(model.StudentProfileId);
            if (existingProfile == null) return false;

            _mapper.Map(model, existingProfile);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
