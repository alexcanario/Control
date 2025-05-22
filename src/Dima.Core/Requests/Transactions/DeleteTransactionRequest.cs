namespace Dima.Core.Requests.Transactions;

public class DeleteTransactionRequest(long id, string userId) : Request(userId)
{
	public long Id { get; set; } = id;
}
