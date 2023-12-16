using System.Diagnostics.CodeAnalysis;
using Contracts.Account;
using Contracts.User;

namespace Console.Scenarios.AccountLogout;

public class LogoutAccountScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _accountService;
    private readonly ICurrentUserService _user;
    private readonly ICurrentAccountService _account;

    public LogoutAccountScenarioProvider(ICurrentAccountService account, ICurrentUserService user, IAccountService accountService)
    {
        _account = account;
        _user = user;
        _accountService = accountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_account.Account is null)
        {
            scenario = null;
            return false;
        }

        scenario = new LogoutAccountScenario(_accountService);
        return true;
    }
}