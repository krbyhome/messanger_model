using System.Diagnostics.CodeAnalysis;
using Contracts.Account;
using Contracts.User;

namespace Console.Scenarios.CreateAccount;

public class CreateAccountScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _accountService;
    private readonly ICurrentUserService _user;
    private readonly ICurrentAccountService _account;

    public CreateAccountScenarioProvider(
        ICurrentUserService user,
        ICurrentAccountService account,
        IAccountService accountService)
    {
        _user = user;
        _account = account;
        _accountService = accountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_user.User is null
            || _account.Account is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new CreateAccountScenario(_accountService);
        return true;
    }
}