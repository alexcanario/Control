namespace Dima.Core.Models;

public class Category : Entity<long>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
	public string UserId { get; set; } = string.Empty;

	public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}