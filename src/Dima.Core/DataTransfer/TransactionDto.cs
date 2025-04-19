namespace Dima.Core.DataTransfer;

public record TransactionDto(string Title, DateTime PaidOrReceivedAt, ETransactionType Type, decimal Amount, long CategoryId, string UserId);