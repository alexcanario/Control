namespace Dima.Core.Requests.Transactions;

public class GetTransactionsByPeriodRequest(string userId) : PagedRequest(userId)
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}