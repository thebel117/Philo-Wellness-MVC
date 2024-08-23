using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhiloWellnessMVC.Data;
using PhiloWellnessMVC.Data.Entities;
using PhiloWellnessMVC.Models.WellnessModels;

namespace PhiloWellnessMVC.Services
{
    public class WellnessService : IWellnessService
    {
        private readonly PhiloWellnessDbContext _context;

        public WellnessService(PhiloWellnessDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WellnessIndexViewModel>> GetAllWellnessRatingsAsync()
        {
            return await _context.WellnessRatings
                .Include(w => w.StudentProfile) // Ensure StudentProfile navigation property is included
                .Select(record => new WellnessIndexViewModel
                {
                    WellnessId = record.WellnessId,
                    UserName = record.StudentProfile.Name, // Ensure this property exists
                    SelfRating = record.SelfRating, // Change to correct properties if needed
                    FacultyRating = record.FacultyRating,
                    DateRecorded = record.WellnessDate
                })
                .ToListAsync();
        }


        public async Task<WellnessDetailViewModel> GetWellnessByIdAsync(int wellnessId)
        {
            var entity = await _context.WellnessRatings
                .Include(w => w.StudentProfile) // Ensure StudentProfile navigation property is included
                .FirstOrDefaultAsync(w => w.WellnessId == wellnessId);

            if (entity == null) return null;

            return new WellnessDetailViewModel
            {
                WellnessId = entity.WellnessId,
                UserName = entity.StudentProfile.Name, // Ensure this property exists
                SelfRating = entity.SelfRating, // Adjust as per model changes
                FacultyRating = entity.FacultyRating,
                Date = entity.WellnessDate
            };
        }

        public async Task<bool> CreateWellnessAsync(WellnessCreateViewModel model)
        {
            var entity = new WellnessEntity
            {
                WellnessDate = model.Date,
                SelfRating = model.SelfRating, // Ensure correct property is used
                FacultyRating = model.FacultyRating,
                StudentProfileId = model.UserId // Ensure this is correctly referenced
            };

            _context.WellnessRatings.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateWellnessAsync(WellnessEditViewModel model)
        {
            var entity = await _context.WellnessRatings.FindAsync(model.WellnessId);

            if (entity == null) return false;

            entity.WellnessDate = model.Date;
            entity.SelfRating = model.SelfRating; // Adjust as per your needs
            entity.FacultyRating = model.FacultyRating;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteWellnessAsync(int wellnessId)
        {
            var entity = await _context.WellnessRatings.FindAsync(wellnessId);

            if (entity == null) return false;

            _context.WellnessRatings.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
