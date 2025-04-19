var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/v1/transactions/{id}",
		(long id, Handler handler) => handler.Handle(request))
	.WithName("Transactions: Get by id")
	.WithSummary("Get the transaction by id")
	.Produces<Response>();                         




app.MapPost("/v1/transactions",
		(Request request, Handler handler) => handler.Handle(request))
	.WithName("Transactions: Create")
	.WithSummary("Create the new transaction")
	.Produces<Response>();

app.Run();


//request
//response
//handler

public record Request(string Title, DateTime PaidOrReceivedAt, ETransactionType Type, decimal Amount, long CategoryId, string UserId) 
	: TransactionDto(Title, PaidOrReceivedAt, Type, Amount, CategoryId, UserId);

public record Response(long Id, string Title);

public class Handler
{
	public Response Handle(Request request)
	{
		// Simulate some processing
		// Persist the transaction to a database or perform some business logic
		return new Response(Id: 2, Title: request.Title);
	}
}