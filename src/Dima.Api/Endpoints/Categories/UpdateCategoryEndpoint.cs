using Dima.Api.Common.Api;

namespace Dima.Api.Endpoints.Categories;

public class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPut("/", HandleAsync)
            .Produces<Response<Category?>>()
            .WithName("UpdateCategory")
            .WithSummary("Updates an existing category")
            .WithDescription("Update an existing category in the system")
            .WithOrder(2);

    private static async Task<IResult> HandleAsync(UpdateCategoryRequest command, ICategoryHandler handler, HttpContext httpContext)
    {
        if(string.IsNullOrEmpty(command.Title) 
           || string.IsNullOrEmpty(command.Description)
              || command.Id <= 0)
                return Results.BadRequest("Invalid request data.");
           
		var userId = httpContext.User.Identity!.Name ?? string.Empty;

		command.UserId = userId;
		var response = await handler.UpdateAsync(command);

        return response.IsSuccess
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }
}