using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhiloWellnessMVC.Data;
using PhiloWellnessMVC.Data.Entities;
using PhiloWellnessMVC.Models.StudentProfileModels;
using PhiloWellnessMVC.Models.WellnessModels;
using PhiloWellnessMVC.Models.VisitModels;

namespace PhiloWellnessMVC.Services.StudentProfileServices
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
                    Name = profile.FirstName + " " + profile.LastName, // concatenate FirstName and LastName
                    Grade = profile.Grade,
                    StudentIdNumber = profile.StudentIdNumber //  as a string
                })
                .ToListAsync();
        }

        public async Task<StudentProfileDetailViewModel> GetStudentProfileByIdAsync(string studentProfileId)
        {
            var entity = await _context.StudentProfiles
                .Include(sp => sp.WellnessRatings)
                .FirstOrDefaultAsync(sp => sp.StudentProfileId == studentProfileId); // Use '==' for comparison

            if (entity == null) return null;

            return new StudentProfileDetailViewModel
            {
                StudentProfileId = entity.StudentProfileId,
                Name = entity.FirstName + " " + entity.LastName,
                Grade = entity.Grade,
                StudentIdNumber = entity.StudentIdNumber, // treat it as a string instead
                WellnessRecords = entity.WellnessRatings
                    .Select(r => new WellnessIndexViewModel
                    {
                        WellnessId = r.WellnessId,
                        SelfRating = r.SelfRating,
                        FacultyRating = r.FacultyRating,
                        Date = r.DateRecorded
                    }).ToList()
            };
        }


public async Task<bool> CreateStudentProfileAsync(StudentProfileCreateViewModel model)
{
    // Check if the UserId exists in the Users table
    var userExists = await _context.Users.AnyAsync(u => u.UserId == model.UserId.ToString());
    if (!userExists)
    {
        throw new InvalidOperationException("The provided UserId does not exist in the Users table.");
    }

    // Create the StudentProfileEntity object with the necessary properties
    var entity = new StudentProfileEntity
    {
        UserId = model.UserId.ToString(),  // Assuming UserId needs to be converted to string
        FirstName = model.FirstName,       // Directly use FirstName from the model
        LastName = model.LastName,         // Directly use LastName from the model
        Grade = model.Grade,
        StudentIdNumber = model.StudentIdNumber,
        // Add any additional properties if necessary
    };

    // Add the entity to the context and save changes
    _context.StudentProfiles.Add(entity);
    return await _context.SaveChangesAsync() == 1;  // Return true if exactly one record is affected
}




        public async Task<bool> UpdateStudentProfileAsync(StudentProfileEditViewModel model)
        {
            var entity = await _context.StudentProfiles.FindAsync(model.StudentProfileId);

            if (entity == null) return false;

            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Grade = model.Grade;
            entity.StudentIdNumber = model.StudentIdNumber; // Treated as a string

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteStudentProfileAsync(int studentId)
        {
            var entity = await _context.StudentProfiles.FindAsync(studentId);

            if (entity == null) return false;

            _context.StudentProfiles.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public Task<StudentProfileDetailViewModel> GetStudentProfileByIdAsync(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
