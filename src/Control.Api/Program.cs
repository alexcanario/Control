using Control.Core.Models.Requests;
using Control.Core.Models.Responses;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds( y => y.FullName ); });
builder.Services.AddTransient<Handler>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost(
    "/v1/categories", 
    (Request request, Handler handler) => handler.Handle(request))
    .WithName("Transactions: Create")
    .WithSummary("Create a new transaction")
    .Produces<Response>();

app.Run();

public class Handler
{
    public Response Handle(Request request)
    {
        return new Response { Id = 4, Title =  request.Title };
    }
}