using Dima.Api.Common.Api;
using Dima.Core.Requests.Transactions;

namespace Dima.Api.Endpoints.Transactions;

public class UpdateTransactionEndpoint : IEndpoint
{
	public static void Map(IEndpointRouteBuilder app)
	{
		app.MapPut("/", HandleAsync)
			.Produces<Response<Transaction?>>()
			.WithName("UpdateTransaction")
			.WithSummary("Updates a transaction")
			.WithDescription("Update a transaction in the system")
			.WithOrder(2);
	}

	private static async Task<IResult> HandleAsync(ITransactionHandler handler, UpdateTransactionRequest command, HttpContext httpContext)
	{
		var userId = httpContext.User.Identity!.Name ?? string.Empty;
		command.UserId = userId; 

		var result = await handler.UpdateAsync(command);
		
		return result.IsSuccess
			? Results.Ok(result.Data)
			: Results.BadRequest(result);
	}
}