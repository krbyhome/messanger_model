using System.Diagnostics.CodeAnalysis;
using Contracts.Account;
using Contracts.User;

namespace Console.Scenarios.DepositMoney;

public class DepositMoneyScenarioProvider : IScenarioProvider
{
    private readonly ICurrentAccountService _account;
    private readonly ICurrentUserService _user;
    private readonly IAccountService _accountService;

    public DepositMoneyScenarioProvider(ICurrentAccountService account, ICurrentUserService user, IAccountService accountService)
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

        scenario = new DepositMoneyScenario(_accountService);
        return true;
    }
}