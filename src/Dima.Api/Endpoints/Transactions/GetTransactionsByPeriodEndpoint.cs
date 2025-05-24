using Dima.Api.Common.Api;
using Dima.Core.Requests.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions;

public class GetTransactionsByPeriodEndpoint : IEndpoint
{
	public static void Map(IEndpointRouteBuilder app)
	{
		app.MapGet("/", HandleAsync)
			.Produces<PagedResponse<IEnumerable<Transaction>>>()
			.WithName("GetTransactionsByPeriod")
			.WithSummary("Get transactions by period")
			.WithDescription("Retrieves transactions from the system using a specific period")
			.WithOrder(5);
	}

	private static async Task<IResult> HandleAsync([FromBody] GetTransactionsByPeriodRequest request, ITransactionHandler handler)
	{																				   
		request.UserId = "alexcanario@"; // TODO: Remove this line when authentication is implemented
		var result = await handler.GetByPeriodAsync(request);
		
		return result.IsSuccess
			? Results.Ok(result.Data)
			: Results.NotFound(result);
	}
}