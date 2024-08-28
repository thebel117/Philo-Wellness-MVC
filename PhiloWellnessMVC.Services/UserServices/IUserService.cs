using System.Threading.Tasks;
using PhiloWellnessMVC.Models.UserModels;

namespace PhiloWellnessMVC.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserCreateViewModel model);
    }
}
