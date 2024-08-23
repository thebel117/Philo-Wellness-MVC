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
                .Include(w => w.StudentProfile) // Ensure StudentProfile is included
                .Select(record => new WellnessIndexViewModel
                {
                    WellnessId = record.WellnessId,
                    StudentName = record.StudentProfile.Name,
                    WellnessDate = record.WellnessDate,
                    WellnessScore = record.WellnessScore
                })
                .ToListAsync();
        }

        public async Task<WellnessDetailViewModel> GetWellnessByIdAsync(int wellnessId)
        {
            var entity = await _context.WellnessRatings
                .Include(w => w.StudentProfile) // Ensure StudentProfile is included
                .FirstOrDefaultAsync(w => w.WellnessId == wellnessId);

            if (entity == null) return null;

            return new WellnessDetailViewModel
            {
                WellnessId = entity.WellnessId,
                StudentName = entity.StudentProfile.Name,
                WellnessDate = entity.WellnessDate,
                WellnessScore = entity.WellnessScore
            };
        }

        public async Task<bool> CreateWellnessAsync(WellnessCreateViewModel model)
        {
            var entity = new WellnessEntity
            {
                WellnessDate = model.WellnessDate,
                WellnessScore = model.WellnessScore,
                StudentProfileId = model.StudentProfileId // Ensure correct foreign key
            };

            _context.WellnessRatings.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateWellnessAsync(WellnessEditViewModel model)
        {
            var entity = await _context.WellnessRatings.FindAsync(model.WellnessId);

            if (entity == null) return false;

            entity.WellnessDate = model.WellnessDate;
            entity.WellnessScore = model.WellnessScore;

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
