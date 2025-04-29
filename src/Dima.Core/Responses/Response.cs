namespace Dima.Core.Responses;

public class Response<TData>(TData data, string message = null, int code = 200)
{
	public TData? Data { get; set; } = data;
	public string? Message { get; set; } = message;

	public bool IsSuccess => code is >= 200 and < 300;
}