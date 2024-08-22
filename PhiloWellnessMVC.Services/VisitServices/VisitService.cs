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
                StudentProfileId = model.StudentProfileId
            };

            _context.Visits.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<VisitIndexViewModel>> GetAllVisitsAsync()
        {
            return await _context.Visits
                .Select(visit => new VisitIndexViewModel
                {
                    VisitId = visit.VisitId,
                    VisitDate = visit.VisitDate,
                    ReasonForVisit = visit.ReasonForVisit,
                    StudentFullName = visit.StudentProfile.FirstName + " " + visit.StudentProfile.LastName
                })
                .ToListAsync();
        }

        public async Task<VisitDetail> GetVisitByIdAsync(int visitId)
        {
            var entity = await _context.Visits
                .Include(visit => visit.StudentProfile)
                .FirstOrDefaultAsync(visit => visit.VisitId == visitId);

            if (entity == null) return null;

            return new VisitDetail
            {
                VisitId = entity.VisitId,
                VisitDate = entity.VisitDate,
                ReasonForVisit = entity.ReasonForVisit,
                StudentProfileId = entity.StudentProfileId,
                StudentFullName = entity.StudentProfile.FirstName + " " + entity.StudentProfile.LastName
            };
        }

        public async Task<bool> UpdateVisitAsync(VisitEdit model)
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

        Task<VisitDetailViewModel> IVisitService.GetVisitByIdAsync(int visitId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateVisitAsync(VisitEditViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
