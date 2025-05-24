using Dima.Api.Common.Api;
using Dima.Core.Requests.Transactions;

namespace Dima.Api.Endpoints.Transactions;

public class DeleteTransactionEndpoint : IEndpoint
{
	public static void Map(IEndpointRouteBuilder app)
	{
		app.MapDelete("/{id:long}", HandleAsync)
			.Produces<Response<Transaction?>>(StatusCodes.Status500InternalServerError)
			.WithName("DeleteTransaction")
			.WithSummary("Deletes a transaction")
			.WithDescription("Delete a transaction from the system")
			.WithOrder(3);
	}

	private static async Task<IResult> HandleAsync(ITransactionHandler handler, long id)
	{
		const string userId = "alexcanario@";
		var result = await handler.DeleteAsync(new DeleteTransactionRequest(id, userId));
		
		return result.IsSuccess
			? Results.Ok(result)
			: Results.BadRequest(result);
	}
}