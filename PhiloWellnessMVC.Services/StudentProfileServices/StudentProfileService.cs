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
                    StudentProfileId = profile.StudentProfileId,
                    Name = profile.FirstName + " " + profile.LastName, // Concatenate FirstName and LastName
                    Grade = profile.Grade,
                    StudentIdNumber = profile.StudentIdNumber // Added to match the model
                })
                .ToListAsync();
        }


        public async Task<StudentProfileDetailViewModel> GetStudentProfileByIdAsync(int studentProfileId)
        {
            var entity = await _context.StudentProfiles
                .Include(sp => sp.WellnessRatings)
                .FirstOrDefaultAsync(sp => sp.StudentProfileId == studentProfileId);

            if (entity == null) return null;

            return new StudentProfileDetailViewModel
            {
                StudentProfileId = entity.StudentProfileId,
                Name = entity.FirstName + " " + entity.LastName,
                Grade = entity.Grade,
                StudentIdNumber = entity.StudentIdNumber,
                WellnessRecords = entity.WellnessRatings
                    .Select(r => new WellnessDetailViewModel
                    {
                        WellnessId = r.WellnessId,
                        SelfRating = r.SelfRating,
                        FacultyRating = r.FacultyRating,
                        Incidents = r.Incidents,
                        Date = r.DateRecorded
                    }).ToList()
            };
        }


        public async Task<bool> CreateStudentProfileAsync(StudentProfileCreateViewModel model)
        {
            var entity = new StudentProfileEntity
            {
                FirstName = model.Name.Split(' ')[0], // Assuming name format "First Last"
                LastName = model.Name.Split(' ').Length > 1 ? model.Name.Split(' ')[1] : string.Empty,
                Grade = model.Grade,
                StudentIdNumber = model.StudentIdNumber, // Added to match the model
                                                         // Map additional properties if necessary
            };

            _context.StudentProfiles.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateStudentProfileAsync(StudentProfileEditViewModel model)
        {
            var entity = await _context.StudentProfiles.FindAsync(model.StudentProfileId);

            if (entity == null) return false;

            entity.FirstName = model.FirstName; // Ensure properties are updated
            entity.LastName = model.LastName;
            entity.Grade = model.Grade;
            entity.StudentIdNumber = model.StudentId; // Update with the correct property if needed

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
