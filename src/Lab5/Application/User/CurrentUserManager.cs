using Contracts.User;

namespace Application.User;

public class CurrentUserManager : ICurrentUserService
{
    public Models.Users.User? User { get; set; }
}