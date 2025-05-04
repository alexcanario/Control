using Dima.Api.Data;
using Dima.Api.Handlers;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	//c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dima API", Version = "v1" });
	//c.CustomOperationIds(e => e.ActionDescriptor.RouteValues["action"]);
	c.CustomSchemaIds(type => type.FullName);
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

app.UseSwagger();
//app.UseSwaggerUI(c =>
//	{
//		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dima API V1");
//		c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
//	});

app.UseSwaggerUI();

app.MapPost("/", (Request, CategoryHandler) => { });

app.Run();