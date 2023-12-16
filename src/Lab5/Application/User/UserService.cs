using System.Collections.ObjectModel;
using Abstractions.Repositories;
using Application.Loggers;
using Contracts.Logger;
using Contracts.User;
using Models.Operations;
using Models.Users;

namespace Application.User;

public class UserService : IUserService
{
    private readonly IUserRepository _users;
    private readonly IOperationRepository _operations;
    private readonly IUserOperationLogger _operationLogger;

    public UserService(
        IUserRepository users,
        IOperationRepository operations,
        ICurrentUserService userManager)
    {
        _users = users;
        _operations = operations;
        UserManager = userManager;

        _operationLogger = new UserOperationLogger(users, operations, userManager);
    }

    public ICurrentUserService UserManager { get; set; }

    public SignUpResult Registration(string username, string password)
    {
        Task.Run(async () =>
        {
            await _users.AddUser(username, password).ConfigureAwait(false);
        }).GetAwaiter().GetResult();

        _operationLogger.LogRegistration(username, OperationResult.Success);
        return new SignUpResult.Success();
    }

    public LogInResult Login(string username, string password)
    {
        Models.Users.User? user = _users.FindUserByUserName(username).Result;

        if (user is null)
        {
            _operationLogger.LogLogin(username, OperationResult.Fail);
            return new LogInResult.UserNotFound();
        }

        if (user.Password != password)
        {
            _operationLogger.LogLogin(username, OperationResult.Fail);
            return new LogInResult.WrongPassword();
        }

        _operationLogger.LogLogin(username, OperationResult.Success);
        UserManager.User = user;
        return new LogInResult.Success();
    }

    public LogInResult AdminLogin(string username, string password)
    {
        const string adminPass = "adminPassword";

        Models.Users.User? user = _users.FindUserByUserName(username).Result;

        if (user is null)
        {
            _operationLogger.LogLogin(username, OperationResult.Fail);
            return new LogInResult.UserNotFound();
        }

        if (password == adminPass)
        {
            _users.ChangeRole(user, UserRole.Admin);
            UserManager.User = user with { Role = UserRole.Admin };
            return new LogInResult.Success();
        }

        return new LogInResult.WrongPassword();
    }

    public void Logout()
    {
        if (UserManager.User is not null)
        {
            _operationLogger.LogLogout();
        }

        UserManager.User = null;
    }

    public IReadOnlyCollection<Operation?> ShowOperationHistory()
    {
        if (UserManager.User is not null)
        {
            return _operations.GetOperations(UserManager.User.Name).Result;
        }

        return new ReadOnlyCollection<Operation?>(new List<Operation?>());
    }
}