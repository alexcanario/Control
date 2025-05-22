namespace Dima.Core.Models;

public sealed class Transaction : Entity<long>
{
    public string Title { get; private set; } =  string.Empty;
    public DateTime? PaidOrReceivedAt { get; private set; }
    public ETransactionType Type { get; private set; } = ETransactionType.Withdrawal;
	public decimal Amount { get; private set; }
    public long CategoryId { get; private set; }
	public long? TransactionId { get; private set; }
	public Category Category { get; private set; } =  null!;
    public string UserId { get; private set; } =   string.Empty;

    public static Transaction Create(string title, ETransactionType type, decimal amount, 
        long categoryId, DateTime? paidOrReceiveAt, string userId)
    {
        return new Transaction
        {
            Title = title,
            Type = type,
            Amount = amount,
            CategoryId = categoryId,
            PaidOrReceivedAt = paidOrReceiveAt,
            UserId = userId
        };
    }

	public void Update(string title, ETransactionType type, decimal amount, long categoryId, DateTime? paidOrReceiveAt)
	{
		Title = title;
		Type = type;
		Amount = amount;
		CategoryId = categoryId;
		PaidOrReceivedAt = paidOrReceiveAt;
	}
}