using System.Text.Json.Serialization;

namespace Dima.Core.Responses;

public class PagedResponse<TData> : Response<TData>
{
	[JsonConstructor]
	public PagedResponse(TData? data, int totalCount, int currentPage, int pageSize = Configuration.DefaultPageSize) 
		: base(data)
	{
		TotalCount = totalCount;
		CurrentPage = currentPage;
		PageSize = pageSize;
	}

	public PagedResponse(TData? data, int statusCode = Configuration.DefaultStatusCode, string? message = null)
		: base(data, statusCode, message)
	{
	}

	public int CurrentPage { get; set; }
	public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
	public int PageSize { get; set; }
	public int TotalCount { get; set; }
}