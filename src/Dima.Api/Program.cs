using Dima.Api.Data;
using Dima.Api.Endpoints;
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
builder.Services.AddScoped<ITransactionHandler, TransactionHandler>();

var app = builder.Build();

app.MapEndpoints();

if(builder.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/openapi/v1.json", "Dima Api"));
}

app.Run();