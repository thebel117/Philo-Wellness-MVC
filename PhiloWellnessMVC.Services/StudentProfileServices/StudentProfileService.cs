using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhiloWellnessMVC.Data;
using PhiloWellnessMVC.Data.Entities;
using PhiloWellnessMVC.Models.StudentProfileModels;
using PhiloWellnessMVC.Services;

namespace PhiloWellnessMVC.Services
{
    public class StudentProfileService : IStudentProfileService
    {
        private readonly PhiloWellnessDbContext _context;

        public StudentProfileService(PhiloWellnessDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentProfileIndexViewModel>> GetAllStudentProfilesAsync()
        {
            return await _context.StudentProfiles
                .Select(profile => new StudentProfileIndexViewModel
                {
                    StudentId = profile.StudentId,
                    Name = profile.Name,
                    Grade = profile.Grade
                })
                .ToListAsync();
        }

        public async Task<StudentProfileDetailViewModel> GetStudentProfileByIdAsync(int studentId)
        {
            var entity = await _context.StudentProfiles
                .Include(sp => sp.WellnessRatings) // Ensure WellnessRatings is included
                .FirstOrDefaultAsync(sp => sp.StudentId == studentId);

            if (entity == null) return null;

            return new StudentProfileDetailViewModel
            {
                StudentId = entity.StudentId,
                Name = entity.Name,
                Grade = entity.Grade,
                WellnessRecords = entity.WellnessRatings // Changed from WellnessRecords to WellnessRatings
                    .Select(r => new WellnessRecordViewModel
                    {
                        WellnessId = r.WellnessId,
                        WellnessDate = r.WellnessDate,
                        WellnessScore = r.WellnessScore
                    }).ToList()
            };
        }

        public async Task<bool> CreateStudentProfileAsync(StudentProfileCreateViewModel model)
        {
            var entity = new StudentProfileEntity
            {
                Name = model.Name,
                Grade = model.Grade
            };

            _context.StudentProfiles.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateStudentProfileAsync(StudentProfileEditViewModel model)
        {
            var entity = await _context.StudentProfiles.FindAsync(model.StudentId);

            if (entity == null) return false;

            entity.Name = model.Name;
            entity.Grade = model.Grade;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteStudentProfileAsync(int studentId)
        {
            var entity = await _context.StudentProfiles.FindAsync(studentId);

            if (entity == null) return false;

            _context.StudentProfiles.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
