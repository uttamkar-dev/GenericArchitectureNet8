
using DataAccess.Models;

namespace DataAccess.Service.Interfaces;

public interface IUserService
{
    Task<UserModel> CreateUserAsync(UserModel user);
}
