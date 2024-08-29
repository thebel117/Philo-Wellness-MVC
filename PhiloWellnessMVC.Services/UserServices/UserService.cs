using System;
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
                UserId = GenerateShortGuid(), // Generate a 12-character UserId
                Email = model.Email,
                Role = model.Role,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            _context.Users.Add(entity);
            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        private string GenerateShortGuid()
        {
            var guid = Guid.NewGuid(); // Generates a new Guid
            var base64Guid = Convert.ToBase64String(guid.ToByteArray()); // Convert Guid to Base64
            var shortGuid = base64Guid.TrimEnd('=').Replace('/', '_').Replace('+', '-'); // URL-safe Base64 encoding
            return shortGuid.Substring(0, 12); // Trim down to just 12 characters
        }
    }
}
