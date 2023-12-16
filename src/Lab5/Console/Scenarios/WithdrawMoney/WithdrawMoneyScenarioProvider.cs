using System.Diagnostics.CodeAnalysis;
using Contracts.Account;
using Contracts.User;

namespace Console.Scenarios.WithdrawMoney;

public class WithdrawMoneyScenarioProvider : IScenarioProvider
{
    private readonly ICurrentAccountService _account;
    private readonly ICurrentUserService _user;
    private readonly IAccountService _accountService;

    public WithdrawMoneyScenarioProvider(IAccountService accountService, ICurrentUserService user, ICurrentAccountService account)
    {
        _accountService = accountService;
        _user = user;
        _account = account;
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

        scenario = new WithdrawMoneyScenario(_accountService);
        return true;
    }
}