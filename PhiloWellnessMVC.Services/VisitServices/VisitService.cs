using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhiloWellnessMVC.Data;
using PhiloWellnessMVC.Data.Entities;
using PhiloWellnessMVC.Models.VisitModels;

namespace PhiloWellnessMVC.Services
{
    public class VisitService : IVisitService
    {
        private readonly PhiloWellnessDbContext _context;

        public VisitService(PhiloWellnessDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateVisitAsync(VisitCreateViewModel model)
        {
            var entity = new VisitEntity
            {
                VisitDate = model.VisitDate,
                ReasonForVisit = model.ReasonForVisit,
                UserId = model.UserId // Changed from StudentIdNumber to UserId
            };

            _context.Visits.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<VisitIndexViewModel>> GetAllVisitsAsync()
        {
            return await _context.Visits
                .Include(v => v.User) // Ensure User is included
                .Select(visit => new VisitIndexViewModel
                {
                    VisitId = visit.VisitId,
                    VisitDate = visit.VisitDate,
                    ReasonForVisit = visit.ReasonForVisit,
                    UserName = visit.User.Name // Changed from StudentProfile.Name to User.Name
                })
                .ToListAsync();
        }

        public async Task<VisitDetailViewModel> GetVisitByIdAsync(int visitId)
        {
            var entity = await _context.Visits
                .Include(v => v.User) // Ensure User is included
                .FirstOrDefaultAsync(v => v.VisitId == visitId);

            if (entity == null) return null;

            return new VisitDetailViewModel
            {
                VisitId = entity.VisitId,
                VisitDate = entity.VisitDate,
                ReasonForVisit = entity.ReasonForVisit,
                UserId = entity.UserId, // Changed from StudentProfileId to UserId
                UserName = entity.User.Name // Changed from StudentProfile.FirstName + " " + StudentProfile.LastName to User.Name
            };
        }

        public async Task<bool> UpdateVisitAsync(VisitEditViewModel model)
        {
            var entity = await _context.Visits.FindAsync(model.VisitId);

            if (entity == null) return false;

            entity.VisitDate = model.VisitDate;
            entity.ReasonForVisit = model.ReasonForVisit;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteVisitAsync(int visitId)
        {
            var entity = await _context.Visits.FindAsync(visitId);

            if (entity == null) return false;

            _context.Visits.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
