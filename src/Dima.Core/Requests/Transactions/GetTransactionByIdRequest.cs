namespace Dima.Core.Requests.Transactions;

public class GetTransactionByIdRequest(long id, string userId) : Request(userId)
{
	public long Id { get; } = id;
}