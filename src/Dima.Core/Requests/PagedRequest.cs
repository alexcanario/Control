namespace Dima.Core.Requests;

public abstract class PagedRequest(string userId) : Request(userId)
{
	public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
	public int PageSize { get; set; } = Configuration.DefaultPageSize;
}