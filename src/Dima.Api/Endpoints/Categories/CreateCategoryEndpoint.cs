using Dima.Api.Common.Api;

namespace Dima.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
	public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/", HandleAsync)
            .Produces<Response<Category?>>()
            .WithName("CreateCategory")
            .WithSummary("Creates a new category")
            .WithDescription("Create a new category in the system")
            .WithOrder(1);

	private static async Task<IResult> HandleAsync(CreateCategoryRequest command, ICategoryHandler handler)
	{
        if (string.IsNullOrWhiteSpace(command.Title) || string.IsNullOrWhiteSpace(command.Description))
        {
            return Results.BadRequest(new Response<Category>(null, StatusCodes.Status400BadRequest, "Title and description are required."));
        }
        
        var response = await handler.CreateAsync(command);
		var locationUrl = $"/{response.Data?.Id}";

		return response.IsSuccess
			? Results.Created(locationUrl, response)
			: Results.InternalServerError(response);
	}
}