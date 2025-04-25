using Dima.Core.Models;

namespace Dima.Core.DataTransfer;

public class TransactionDto
{
	public string Title { get; set; } = string.Empty;
	public DateTime PaidOrReceivedAt { get; set; }
	public ETransactionType Type { get; set; } = ETransactionType.Withdraw;
	public decimal Amount { get; set; }
	public long CategoryId { get; set; }
	public Category Category { get; set; } = null!;
	public string UserId { get; set; } = string.Empty;
}