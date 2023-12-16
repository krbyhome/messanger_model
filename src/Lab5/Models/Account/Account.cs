namespace Models.Account;

public record Account(
    long Id,
    long UserId,
    string Name,
    long Balance,
    string PinCode);