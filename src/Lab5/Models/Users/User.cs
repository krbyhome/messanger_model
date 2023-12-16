namespace Models.Users;

public record User(
    long Id,
    string Name,
    string Password,
    UserRole Role);