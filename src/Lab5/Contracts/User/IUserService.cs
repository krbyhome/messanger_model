using Models.Operations;

namespace Contracts.User;

public interface IUserService
{
    ICurrentUserService UserManager { get; set; }
    SignUpResult Registration(string username, string password);
    LogInResult Login(string username, string password);
    LogInResult AdminLogin(string username, string password);
    void Logout();
    IReadOnlyCollection<Operation?> ShowOperationHistory();
}