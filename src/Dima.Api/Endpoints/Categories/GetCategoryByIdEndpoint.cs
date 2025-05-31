using Dima.Api.Common.Api;

namespace Dima.Api.Endpoints.Categories;

public class GetCategoryByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/{id:long}", HandleAsync)
            .Produces<Response<Category>>()
            .WithName("GetCategoryById")
            .WithSummary("Get a category by its ID")
            .WithDescription("Retrieves a category from the system using its unique identifier")
            .WithOrder(4);

    private static async Task<IResult> HandleAsync(long id, ICategoryHandler handle, HttpContext httpContext)
    {
        if (id <= 0)
            return Results.BadRequest("Id inválido.");

		var userId = httpContext.User.Identity!.Name ?? string.Empty;
		var response = await handle.GetByIdAsync(new GetCategoryByIdRequest(id, userId));
        
        return response.IsSuccess 
            ? Results.Ok(response.Data) 
            : Results.NotFound(response);
    }
}