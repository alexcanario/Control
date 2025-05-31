using Dima.Api.Common.Api;
using Dima.Core.Requests.Transactions;

namespace Dima.Api.Endpoints.Transactions;

public class GetTransactionByIdEndpoint : IEndpoint
{
	public static void Map(IEndpointRouteBuilder app)
	{
		app.MapGet("/{id:long}", HandleAsync)
			.Produces<Response<Transaction?>>()
			.WithName("GetTransactionById")
			.WithSummary("Get a transaction by its ID")
			.WithDescription("Retrieves a transaction from the system using its unique identifier")
			.WithOrder(4);
	}

	private static async Task<IResult> HandleAsync(ITransactionHandler handler, long id, HttpContext httpContext)
	{
		var userId = httpContext.User.Identity!.Name ?? string.Empty;
		var result = await handler.GetByIdAsync(new GetTransactionByIdRequest(id, userId));
		
		return result.IsSuccess
			? Results.Ok(result.Data)
			: Results.NotFound(result);
	}
}