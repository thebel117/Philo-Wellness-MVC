using System.Collections.Generic;
using System.Threading.Tasks;
using PhiloWellnessMVC.Models.WellnessModels;

namespace PhiloWellnessMVC.Services
{
    public interface IWellnessService
    {
        Task<IEnumerable<WellnessIndexViewModel>> GetAllWellnessRatingsAsync();
        Task<WellnessDetailViewModel> GetWellnessByIdAsync(int wellnessId);
        Task<bool> CreateWellnessAsync(WellnessCreateViewModel model);
        Task<bool> UpdateWellnessAsync(WellnessEditViewModel model);
        Task<bool> DeleteWellnessAsync(int wellnessId);
    }
}
