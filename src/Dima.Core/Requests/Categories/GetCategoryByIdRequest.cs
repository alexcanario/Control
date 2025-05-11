namespace Dima.Core.Requests.Categories;

public class GetCategoryByIdRequest(long id, string userId) : Request(userId)
{
	public long Id { get; set; } = id;
}