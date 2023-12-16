using System.Diagnostics.CodeAnalysis;
using Contracts.User;

namespace Console.Scenarios.OperationHistory;

public class ShowHistoryScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _user;

    public ShowHistoryScenarioProvider(IUserService userService, ICurrentUserService user)
    {
        _userService = userService;
        _user = user;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_user.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ShowHistoryScenario(_userService);
        return true;
    }
}