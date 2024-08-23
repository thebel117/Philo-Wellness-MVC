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
                UserId = model.UserId // Ensure that UserId is used consistently
            };

            _context.Visits.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }


        public async Task<IEnumerable<VisitIndexViewModel>> GetAllVisitsAsync()
        {
            return await _context.Visits
                .Include(v => v.User) // Ensure the User navigation property is included
                .Select(visit => new VisitIndexViewModel
                {
                    VisitId = visit.VisitId,
                    VisitDate = visit.VisitDate,
                    ReasonForVisit = visit.ReasonForVisit,
                    UserName = visit.User.Name // Ensure User.Name or equivalent property exists
                })
                .ToListAsync();
        }


        public async Task<VisitDetailViewModel> GetVisitByIdAsync(int visitId)
        {
            var entity = await _context.Visits
                .Include(v => v.User)
                .FirstOrDefaultAsync(v => v.VisitId == visitId);

            if (entity == null) return null;

            return new VisitDetailViewModel
            {
                VisitId = entity.VisitId,
                VisitDate = entity.VisitDate,
                ReasonForVisit = entity.ReasonForVisit,
                UserId = entity.UserId,
                UserName = entity.User.Name // Ensure that the User.Name or equivalent property exists
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
