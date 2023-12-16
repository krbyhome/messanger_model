using System.Diagnostics.CodeAnalysis;
using Contracts.Account;
using Contracts.User;

namespace Console.Scenarios.Balance;

public class ShowBalanceScenarioProvider : IScenarioProvider
{
    private readonly ICurrentAccountService _account;
    private readonly ICurrentUserService _user;
    private readonly IAccountService _accountService;

    public ShowBalanceScenarioProvider(ICurrentAccountService account, ICurrentUserService user, IAccountService accountService)
    {
        _account = account;
        _user = user;
        _accountService = accountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_user.User is null
            || _account.Account is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ShowBalanceScenario(_accountService);
        return true;
    }
}