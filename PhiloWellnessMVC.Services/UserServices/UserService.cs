using System.Threading.Tasks;
using PhiloWellnessMVC.Data;
using PhiloWellnessMVC.Data.Entities;
using PhiloWellnessMVC.Models.UserModels;

namespace PhiloWellnessMVC.Services
{
    public class UserService : IUserService
    {
        private readonly PhiloWellnessDbContext _context;

        public UserService(PhiloWellnessDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUserAsync(UserCreateViewModel model)
        {
            var entity = new UserEntity
            {
                UserId = model.UserName,
                Email = model.Email,
                Role = model.Role,
                FirstName = model.FirstName, // Required property
                LastName = model.LastName,   // Required property
            };

            _context.Users.Add(entity);
            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }
    }
}
