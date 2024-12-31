using Control.Core.Models.Requests;
using Control.Core.Models.Responses;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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