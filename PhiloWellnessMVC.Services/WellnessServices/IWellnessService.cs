using PhiloWellnessMVC.Models.WellnessModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhiloWellnessMVC.Services
{
    public interface IWellnessService
    {
        Task<WellnessDetailViewModel> GetWellnessByIdAsync(int wellnessId);
        Task<IEnumerable<WellnessIndexViewModel>> GetAllWellnessAsync();
        Task CreateWellnessAsync(WellnessCreateViewModel model);
        Task UpdateWellnessAsync(WellnessEditViewModel model);
        Task DeleteWellnessAsync(int wellnessId);
    }
}
