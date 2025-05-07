using Dima.Api.Data;
using Dima.Api.Handlers;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

if(builder.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/openapi/v1.json", "Dima Api"));
}

app.MapPost("/v1/categories", async (CreateCategoryRequest command, ICategoryHandler handler) =>
{
	var response = await handler.CreateAsync(command);
})
	.WithName("CreateCategory")
	.Produces<Response<Category>>(StatusCodes.Status201Created)
	.Produces<Response<Category>>(StatusCodes.Status500InternalServerError)
	.WithSummary("Create a new category")
	.WithTags("Categories");


//app.MapPut("/v1/categories", async (UpdateCategoryRequest command, ICategoryHandler handler) =>
//{
//	var response = await handler.UpdateAsync(command);
//})
//.WithName("UpdateCategory")
//	.Produces<Response<Category>>(StatusCodes.Status200OK)
//	.Produces<Response<Category>>(StatusCodes.Status204NoContent)
//	.Produces<Response<Category>>(StatusCodes.Status500InternalServerError)
//	.WithSummary("Update an existing category")
//	.WithTags("Categories");

//app.MapDelete("/v1/categories/{id}", async (DeleteCategoryRequest command, ICategoryHandler handler) =>
//{
//	var response = await handler.DeleteAsync(command);
//})
//	.WithName("DeleteCategory")
//	.Produces<Response<Category>>(StatusCodes.Status200OK)
//	.Produces<Response<Category>>(StatusCodes.Status204NoContent)
//	.Produces<Response<Category>>(StatusCodes.Status500InternalServerError)
//	.WithSummary("Delete an existing category")
//	.WithTags("Categories");


//app.MapGet("/v1/categories", async (GetAllCategoriesRequest request, ICategoryHandler handler) =>
//{
//	var response = await handler.GetAllAsync(request);
//})
//	.WithName("GetAllCategories")
//	.Produces<List<Category>>(StatusCodes.Status200OK)
//	.Produces<Response<Category>>(StatusCodes.Status204NoContent)
//	.WithSummary("Get all categories")
//	.WithTags("Categories");

//app.MapGet("/v1/categories/{id}", async (GetCategoryByIdRequest request, ICategoryHandler handler) =>
//{
//	var response = await handler.GetByIdAsync(request);
//})
//	.WithName("GetCategoryById")
//	.Produces<Response<Category>>(StatusCodes.Status200OK)
//	.Produces<Response<Category>>(StatusCodes.Status204NoContent)
//	.WithSummary("Get a category by ID")
//	.WithTags("Categories");

app.Run();