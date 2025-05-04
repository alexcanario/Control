using Dima.Api.Data;
using Dima.Api.Handlers;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.CustomSchemaIds(type => type.FullName);
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/v1/categories", async (CreateCategoryRequest command, ICategoryHandler handler) =>
{
	var response = await handler.CreateAsync(command);
})
	.WithName("CreateCategory")
	.Produces<Response<Category>>(StatusCodes.Status201Created)
	.Produces<Response<Category>>(StatusCodes.Status400BadRequest)
	.Produces<Response<Category>>(StatusCodes.Status500InternalServerError)
	.WithSummary("Create a new category")
	.WithTags("Categories");

app.Run();