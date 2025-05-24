using Dima.Api.Common.Api;
using Dima.Core.Requests.Transactions;

namespace Dima.Api.Endpoints.Transactions;

public class CreateTransactionEndpoint : IEndpoint
{
	public static void Map(IEndpointRouteBuilder app)
	{
		app.MapPost("/", HandleAsync)
			.Produces<Response<Transaction?>>()
			.WithName("CreateTransaction")
			.WithSummary("Creates a new transaction")
			.WithDescription("Create a new transaction in the system")
			.WithOrder(1);
	}

	private static async Task<IResult> HandleAsync(ITransactionHandler handler, CreateTransactionRequest request)
	{
		var result = await handler.CreateAsync(request);
		return result.IsSuccess
			? Results.Created($"/{result.Data?.Id}", result)
			: Results.BadRequest(result.Data);
	}
}