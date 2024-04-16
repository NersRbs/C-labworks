namespace Models.Histories;

public record History(long Id, long AccountId, DateTime Date, decimal Amount);