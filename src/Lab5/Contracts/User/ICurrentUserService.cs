namespace Contracts.User;

public interface ICurrentUserService
{
    Models.Users.User? User { get; set; }
}