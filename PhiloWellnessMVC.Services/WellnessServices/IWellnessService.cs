using PhiloWellnessMVC.Models.WellnessModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhiloWellnessMVC.Services
{
    public interface IWellnessService
    {
        Task<WellnessDetailViewModel?> GetWellnessByIdAsync(int wellnessId);
        Task<List<WellnessIndexViewModel>> GetAllWellnessRatingsAsync();
        Task<WellnessDetailViewModel?> CreateWellnessAsync(WellnessCreateViewModel model);
        Task<bool> UpdateWellnessAsync(WellnessEditViewModel model);
        Task<bool> DeleteWellnessAsync(int wellnessId);
    }
}
