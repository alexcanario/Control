namespace Dima.Core.Requests.Transactions;

public class CreateTransactionRequest : Request
{
    [Required(ErrorMessage = "Título inválido")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tipo inválido")]
    public ETransactionType Type { get; set; }

    [Required(ErrorMessage = "Valor inválido")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Categoria inválida")]
    public long CategoryId { get; set; }

    public DateTime? PaidOrReceivedAt { get; set; }
}