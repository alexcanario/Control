using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.CustomSchemaIds(n => n.FullName);
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dima.Api", Version = "v1" });
});

builder.Services.AddScoped<Handler>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI( c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dima.Api v1");
		c.RoutePrefix = string.Empty;
	});
}
				   
app.MapGet("/categories", () => new { message = "Hello World!" } );

app.MapPost(
	"/v1/transactions",
	(Request request, Handler handler) => handler.Handle(request))
	.WithName("CreateTransaction")
	.WithSummary("Cria uma nova transação")
	.Produces<Response>();


app.Run();

//request
public class Request
{
	public string Title { get; set; } = string.Empty;
	public DateTime PaidOrReceivedAt { get; set; }
	public int Type { get; set; }
	public decimal Amount { get; set; }
	public long CategoryId { get; set; }
	public string UserId { get; set; } = string.Empty;
}

//response
public class Response
{
	public int Id { get; set; }
	public string Title { get; set; } = string.Empty;
}

//handler
public class Handler
{
	public Response Handle(Request request)
	{
		return new Response
		{
			Id = 4,
			Title = request.Title
		};
	}
}