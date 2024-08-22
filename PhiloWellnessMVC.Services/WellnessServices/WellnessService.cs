using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhiloWellnessMVC.Data;
using PhiloWellnessMVC.Data.Entities;
using PhiloWellnessMVC.Models.WellnessModels;

namespace PhiloWellnessMVC.Services
{
    public class WellnessService : IWellnessService
    {
        private readonly PhiloWellnessDbContext _dbContext;
        private readonly IMapper _mapper;

        public WellnessService(PhiloWellnessDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WellnessDetailViewModel?> GetWellnessByIdAsync(int wellnessId)
        {
            var wellnessEntity = await _dbContext.WellnessRatings
                .Include(w => w.StudentProfile) // Include related data
                .FirstOrDefaultAsync(w => w.WellnessId == wellnessId);

            return wellnessEntity is null ? null : _mapper.Map<WellnessEntity, WellnessDetailViewModel>(wellnessEntity);
        }

        public async Task<List<WellnessIndexViewModel>> GetAllWellnessRatingsAsync()
        {
            var wellnessEntities = await _dbContext.WellnessRatings
                .Select(entity => _mapper.Map<WellnessEntity, WellnessIndexViewModel>(entity))
                .ToListAsync();

            return wellnessEntities;
        }

        public async Task<WellnessDetailViewModel?> CreateWellnessAsync(WellnessCreateViewModel request)
        {
            var wellnessEntity = _mapper.Map<WellnessCreateViewModel, WellnessEntity>(request);

            // Assuming the StudentProfileId is equivalent to UserId in the view model
            wellnessEntity.StudentProfileId = request.UserId;

            _dbContext.WellnessRatings.Add(wellnessEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1 ? _mapper.Map<WellnessEntity, WellnessDetailViewModel>(wellnessEntity) : null;
        }

        public async Task<bool> UpdateWellnessAsync(WellnessEditViewModel request)
        {
            var wellnessExists = await _dbContext.WellnessRatings.AnyAsync(wellness => 
            wellness.WellnessId == request.WellnessId);

            if(!wellnessExists)
                return false;

            var newEntity = _mapper.Map<WellnessEditViewModel, WellnessEntity>(request);
            newEntity.StudentProfileId = request.UserId;

            _dbContext.Entry(newEntity).State = EntityState.Modified;
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteWellnessAsync(int id)
        {
            var wellnessEntity = await _dbContext.WellnessRatings.FindAsync(id);

            if (wellnessEntity == null)
                return false;

            _dbContext.WellnessRatings.Remove(wellnessEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}
