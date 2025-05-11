namespace Dima.Core.Requests;

public abstract class Request
{
	protected Request() { }

	protected Request(string userId) => UserId = userId;

	//to-do: Add validation for userId
	public string UserId { get; set; } = string.Empty;
}