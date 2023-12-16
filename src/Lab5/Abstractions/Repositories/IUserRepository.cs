using Models.Users;

namespace Abstractions.Repositories;

public interface IUserRepository
{
    Task AddUser(string username, string password);
    Task ChangeRole(User user, UserRole role);
    Task<User?> FindUserById(long id);
    Task<User?> FindUserByUserName(string username);
}