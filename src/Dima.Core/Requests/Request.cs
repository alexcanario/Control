using System.Text.Json.Serialization;

namespace Dima.Core.Requests;

public abstract class Request
{
	protected Request() { }

	protected Request(string userId) => UserId = userId;

	[JsonIgnore]
	public string UserId { get; set; } = string.Empty;
}