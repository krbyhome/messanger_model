using System.Diagnostics.CodeAnalysis;
using Contracts.Account;
using Contracts.User;

namespace Console.Scenarios.CheckoutAccount;

public class CheckOutAccountScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly ICurrentUserService _user;
    private readonly ICurrentAccountService _account;

    public CheckOutAccountScenarioProvider(IAccountService service, ICurrentUserService user, ICurrentAccountService account)
    {
        _service = service;
        _user = user;
        _account = account;
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

        scenario = new CheckOutAccountScenario(_service);
        return true;
    }
}