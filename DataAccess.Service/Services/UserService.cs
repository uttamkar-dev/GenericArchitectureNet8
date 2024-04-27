using DataAccess.Entity;
using DataAccess.Infrastructure.Repository.Interfaces;
using DataAccess.Models;
using DataAccess.Service.Interfaces;

namespace DataAccess.Service.Services;

public class UserService(IRepository<User> userRepo) : IUserService
{
    private readonly IRepository<User> _userRepo = userRepo;


    public async Task<UserModel> CreateUserAsync(UserModel user)
    {
        User entity = new()
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };

        var result = await _userRepo.CreateAsync(entity);
        return new UserModel("Uttam", "Kar", "uttam@gmail.com");
    }
}
