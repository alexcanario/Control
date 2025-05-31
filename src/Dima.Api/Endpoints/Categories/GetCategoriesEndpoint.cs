using Dima.Api.Common.Api;

namespace Dima.Api.Endpoints.Categories;

public class GetCategoriesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/", HandleAsync)
            .Produces<Response<IEnumerable<Category>>>()
            .WithName("GetCategories")
            .WithSummary("Get all categories")
            .WithDescription("Retrieves all categories from the system")
            .WithOrder(5);

    private static async Task<IResult> HandleAsync(ICategoryHandler handler)
    {
        var response = await handler.GetAllAsync(new GetAllCategoryRequest("alexcanario@"));
        
        return response.IsSuccess 
            ? Results.Ok(response) 
            : Results.NotFound(response);
    }
}