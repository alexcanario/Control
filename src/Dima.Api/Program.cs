using Dima.Api.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	//c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dima API", Version = "v1" });
	//c.CustomOperationIds(e => e.ActionDescriptor.RouteValues["action"]);
	c.CustomSchemaIds(type => type.FullName);
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<Handler>();


var app = builder.Build();

app.UseSwagger();
//app.UseSwaggerUI(c =>
//	{
//		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dima API V1");
//		c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
//	});

app.UseSwaggerUI();


app.MapGet("/", () => new { message = "Hello World!" });

//app.MapPost("/v1/transactions",
//		(Request request, Handler handler) => handler.Handle(request))
//	.WithName("Transactions: Create")
//	.WithSummary("Create the new transaction")
//	.Produces<Response>();

app.Run();


//request
//response
//handler

public class Request(
	string title,
	DateTime paidOrReceivedAt,
	ETransactionType type,
	decimal amount,
	long categoryId,
	string userId)
{
	public string Title { get; set; } = title;
	public DateTime PaidOrReceivedAt { get; set; } = paidOrReceivedAt;
	public ETransactionType Type { get; set; } = type;
	public decimal Amount { get; set; } = amount;
	public long CategoryId { get; set; } = categoryId;
	public string UserId { get; set; } = userId;
}
	

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