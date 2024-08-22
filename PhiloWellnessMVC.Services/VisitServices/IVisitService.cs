using System.Collections.Generic;
using System.Threading.Tasks;
using PhiloWellnessMVC.Models.VisitModels;

namespace PhiloWellnessMVC.Services
{
    public interface IVisitService
    {
        Task<bool> CreateVisitAsync(VisitCreateViewModel model);
        Task<IEnumerable<VisitIndexViewModel>> GetAllVisitsAsync();
        Task<VisitDetailViewModel> GetVisitByIdAsync(int visitId);
        Task<bool> UpdateVisitAsync(VisitEditViewModel model);
        Task<bool> DeleteVisitAsync(int visitId);
    }
}
