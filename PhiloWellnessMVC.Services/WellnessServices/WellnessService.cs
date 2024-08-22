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
        private readonly PhiloWellnessDbContext _context;
        private readonly IMapper _mapper;

        public WellnessService(PhiloWellnessDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WellnessDetailViewModel?> GetWellnessByIdAsync(int wellnessId)
        {
            var wellness = await _context.WellnessRatings
                .Include(w => w.StudentProfile) // Include related data
                .FirstOrDefaultAsync(w => w.WellnessId == wellnessId);

            if (wellness == null)
            {
                return null;
            }

            return _mapper.Map<WellnessDetailViewModel>(wellness);
        }

        public async Task<IEnumerable<WellnessIndexViewModel>> GetAllWellnessRatingsAsync()
        {
            var wellnessRatings = await _context.WellnessRatings
                .Include(w => w.StudentProfile) // Include related data
                .ToListAsync();

            return _mapper.Map<IEnumerable<WellnessIndexViewModel>>(wellnessRatings);
        }

        public async Task<WellnessDetailViewModel?> CreateWellnessAsync(WellnessCreateViewModel wellnessCreateViewModel)
        {
            var wellnessEntity = _mapper.Map<WellnessEntity>(wellnessCreateViewModel);

            // Assuming the StudentProfileId is equivalent to UserId in the view model
            wellnessEntity.StudentProfileId = wellnessCreateViewModel.UserId;

            _context.WellnessRatings.Add(wellnessEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<WellnessDetailViewModel>(wellnessEntity);
        }

        public async Task<WellnessDetailViewModel?> UpdateWellnessAsync(WellnessEditViewModel wellnessEditViewModel)
        {
            var wellnessEntity = await _context.WellnessRatings
                .Include(w => w.StudentProfile) // Include related data
                .FirstOrDefaultAsync(w => w.WellnessId == wellnessEditViewModel.WellnessId);

            if (wellnessEntity == null)
            {
                return null;
            }

            _mapper.Map(wellnessEditViewModel, wellnessEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<WellnessDetailViewModel>(wellnessEntity);
        }

        public async Task<bool> DeleteWellnessAsync(int wellnessId)
        {
            var wellnessEntity = await _context.WellnessRatings
                .FirstOrDefaultAsync(w => w.WellnessId == wellnessId);

            if (wellnessEntity == null)
            {
                return false;
            }

            _context.WellnessRatings.Remove(wellnessEntity);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<IEnumerable<WellnessIndexViewModel>> GetAllWellnessAsync()
        {
            throw new NotImplementedException();
        }

        Task IWellnessService.CreateWellnessAsync(WellnessCreateViewModel model)
        {
            throw new NotImplementedException();
        }

        Task IWellnessService.UpdateWellnessAsync(WellnessEditViewModel model)
        {
            throw new NotImplementedException();
        }

        Task IWellnessService.DeleteWellnessAsync(int wellnessId)
        {
            throw new NotImplementedException();
        }
    }
}
