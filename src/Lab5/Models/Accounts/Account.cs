namespace Models.Accounts;

public record Account(long Id, string HashedPinCode, decimal Balance);