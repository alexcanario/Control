using Dima.Api.Common.Api;

namespace Dima.Api.Endpoints.Categories;

public class DeleteCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapDelete("/{id:long}", HandleAsync)
            .Produces<Response<Category?>>(StatusCodes.Status500InternalServerError)
            .WithName("DeleteCategory")
            .WithSummary("Deletes a category")
            .WithDescription("Delete a category from the system")
            .WithOrder(3);
            

    private static async Task<IResult> HandleAsync(long id, ICategoryHandler handle, HttpContext httpContext)
    {
        if (id <= 0)
        {
            return Results.BadRequest(new Response<Category>(null, StatusCodes.Status400BadRequest, "The provided id must be greater than zero."));
        }

        var userId = httpContext.User.Identity!.Name ?? string.Empty;
		var response = await handle.DeleteAsync(new DeleteCategoryRequest(id, userId));

        return response.IsSuccess 
            ? Results.Ok(response) 
            : Results.NotFound(response);
    }
}